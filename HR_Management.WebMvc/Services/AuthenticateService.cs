using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.Authentication;
using HR_Management.WebMvc.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR_Management.WebMvc.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthenticateService(IHttpContextAccessor httpContextAccessor,
            IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _localStorage = localStorageService;
        }

        public async Task<Response<int>> Login(LoginViewModel loginModel)
        {
            try
            {
                var response = new Response<int>();
                var request = new AuthenticationRequest()
                {
                    Email = loginModel.Email,
                    Password = loginModel.Password,
                };
                var result = await _httpClient.AuthenticationAsync(request);

                if (result.Token == string.Empty)
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                    response.ValidationErrors = "User not found";
                    return response;
                }
                var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(result.Token);
                var claims = ParsClaims(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));

                var login = _httpContextAccessor.HttpContext
                    .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorage.SetStorage("token", result.Token);

                response.IsSuccess = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStroge(new List<string>()
            {
                "token"
            });
            await _httpContextAccessor.HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<Response<int>> Register(RegisterViewModel registerModel)
        {
            try
            {
                var response = new Response<int>();
                var request = new RegistrationRequest()
                {
                    Email = registerModel.Email,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Password = registerModel.Password,
                    Username = registerModel.Username
                };

                var result = await _httpClient.RegisterAsync(request);

                if (string.IsNullOrEmpty(result.UserId))
                {
                    response.IsSuccess = false;
                }
                else
                {
                    response.IsSuccess = true;
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        private static List<Claim> ParsClaims(JwtSecurityToken jwtSecurityToken)
        {
            var claims = jwtSecurityToken.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, jwtSecurityToken.Subject));
            return claims;
        }
    }
}
