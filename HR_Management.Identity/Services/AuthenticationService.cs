using HR_Management.Application.Cantracts.Identity;
using HR_Management.Application.Models.Identity;
using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSetting> _jwtOptions;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSetting> jwtOptions,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> Authentication(AuthenticationRequest authenticationRequest)
        {
            var user = await _userManager.FindByEmailAsync(authenticationRequest.Email);

            if (user == null)
            {
                throw new Exception($"Invalid Information");
            }

            var result = await _signInManager.PasswordSignInAsync(user, authenticationRequest.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Invalid Information");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthenticationResponse();
            response.Id = user.Id;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.Username = user.UserName;

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (var i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.NameId,user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Name,user.FirstName + user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Value.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var response = new RegistrationResponse();
            var existingUser = await _userManager.FindByEmailAsync(registrationRequest.Email);

            if (existingUser != null)
            {
                throw new Exception($"The User : {registrationRequest.Email} alredy exists");
            }

            var newUser = new ApplicationUser()
            {
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName = registrationRequest.Username,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(newUser, registrationRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Employee");
                response.UserId = newUser.Id;
                return response;
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
        }
    }
}
