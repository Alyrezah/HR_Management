using AutoMapper;
using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveRequest;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public LeaveRequestService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestViewModel createLeaveRequestVm)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveRequestDto = _mapper.Map<CreateLeaveRequestDto>(createLeaveRequestVm);
                AddBearerToken();
                var apiResponse = await _httpClient.LeavRequestPOSTAsync(createLeaveRequestDto);

                if (apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = apiResponse.Id;
                }
                else
                {
                    response.IsSuccess = false;

                    foreach (var item in apiResponse.ErrorMessages)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }

                response.Message = apiResponse.Message;
                return response;
            }
            catch (ApiException<int> ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveRequest(int id)
        {
            try
            {
                var response = new Response<int>();
                AddBearerToken();
                await _httpClient.LeavRequestDELETEAsync(id);
                response.IsSuccess = true;
                return response;
            }
            catch (ApiException<int> ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<LeaveRequestViewModel> GetLeaveRequestBy(int id)
        {
            AddBearerToken();
            var leaveRequest = await _httpClient.LeavRequestGETAsync(id);
            return _mapper.Map<LeaveRequestViewModel>(leaveRequest);
        }

        public async Task<UpdateLeaveRequestViewModel> GetLeaveRequestForUpdate(int id)
        {
            AddBearerToken();
            var leaveRequest = await _httpClient.LeavRequestGETAsync(id);
            return _mapper.Map<UpdateLeaveRequestViewModel>(leaveRequest);
        }

        public async Task<List<LeaveRequestListViewModel>> GetLeaveRequestList()
        {
            AddBearerToken();
            var leaveRequests = await _httpClient.LeavRequestAllAsync();
            return _mapper.Map<List<LeaveRequestListViewModel>>(leaveRequests);
        }

        public async Task<Response<int>> UpdateLeaveRequest(UpdateLeaveRequestViewModel updateLeaveRequestVm)
        {
            try
            {
                var response = new Response<int>();
                var updateLeaveRequestDto = _mapper.Map<UpdateLeaveRequestDto>(updateLeaveRequestVm);
                AddBearerToken();
                await _httpClient.LeavRequestPUTAsync(updateLeaveRequestVm.Id,updateLeaveRequestDto);

                response.IsSuccess = true;
                return response;
            }
            catch (ApiException<int> ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
