using AutoMapper;
using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveAllocation;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public LeaveAllocationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateLeaveAllocation(CreateLeaveAllocationViewModel createLeaveAllocationVm)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveAllocationDto = _mapper.Map<CreateLeaveAllocationDto>(createLeaveAllocationVm);
                AddBearerToken();
                var apiResponse = await _httpClient.LeaveAllocationPOSTAsync(createLeaveAllocationDto);

                if (apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = apiResponse.Id;

                }
                else
                {
                    foreach (var item in apiResponse.ErrorMessages)
                    {
                        response.ValidationErrors += item + Environment.NewLine;
                    }
                }

                response.Message = apiResponse.Message;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveAllocation(int id)
        {
            try
            {
                var response = new Response<int>();
                AddBearerToken();
                await _httpClient.LeaveAllocationDELETEAsync(id);
                response.IsSuccess = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<List<LeaveAllocationViewModel>> GetLeavaAllocationList()
        {
            AddBearerToken();
            var leaveAllocations = await _httpClient.LeaveAllocationAllAsync();
            return _mapper.Map<List<LeaveAllocationViewModel>>(leaveAllocations);
        }

        public async Task<LeaveAllocationViewModel> GetLeaveAllocationBy(int id)
        {
            AddBearerToken();
            var leaveAllocation = await _httpClient.LeaveAllocationGETAsync(id);
            return _mapper.Map<LeaveAllocationViewModel>(leaveAllocation);
        }

        public async Task<UpdateLeaveAllocationViewModel> GetLeaveAllocationForUpdate(int id)
        {
            AddBearerToken();
            var leaveAllocation = await _httpClient.LeaveAllocationGETAsync(id);
            return _mapper.Map<UpdateLeaveAllocationViewModel>(leaveAllocation);
        }

        public async Task<Response<int>> UpdateLeaveAllocation(UpdateLeaveAllocationViewModel updateLeaveAllocationVm)
        {
            try
            {
                var response = new Response<int>();
                var updateLeaveAllocationDto = _mapper.Map<UpdateLeaveAllocationDto>(updateLeaveAllocationVm);
                AddBearerToken();
                await _httpClient.LeaveAllocationPUTAsync(updateLeaveAllocationVm.Id,updateLeaveAllocationDto);

                response.IsSuccess = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }
    }
}
