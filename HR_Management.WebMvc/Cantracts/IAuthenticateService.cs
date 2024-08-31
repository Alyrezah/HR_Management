using HR_Management.WebMvc.Models.Authentication;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Cantracts
{
    public interface IAuthenticateService
    {
        Task<Response<int>> Login(LoginViewModel loginModel);
        Task<Response<int>> Register(RegisterViewModel registerModel);
        Task Logout();
    }
}
