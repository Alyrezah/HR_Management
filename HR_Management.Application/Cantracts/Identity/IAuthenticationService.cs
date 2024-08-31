using HR_Management.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Cantracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authentication(AuthenticationRequest authenticationRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}
