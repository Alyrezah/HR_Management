using HR_Management.WebMvc.Cantracts;

namespace HR_Management.WebMvc.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected Response<Guid> ConvertApiException<Guid>(ApiException apiException)
        {
            switch (apiException.StatusCode)
            {
                case 400:
                    return new Response<Guid>()
                    {
                        Message = "Validation errors have occured.",
                        ValidationErrors = apiException.Response,
                        IsSuccess = false
                    };
                case 404:
                    return new Response<Guid>()
                    {
                        Message = "Error not found.",
                        ValidationErrors = apiException.Response,
                        IsSuccess = false
                    };
                default:
                    return new Response<Guid>()
                    {
                        Message = "Somthing went wrong,try again",
                        ValidationErrors = apiException.Response,
                        IsSuccess = false
                    };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.IsExist("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    _localStorageService.GetStrogeValue<string>("token"));
            }
        }
    }
}
