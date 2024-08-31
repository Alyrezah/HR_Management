using AutoMapper;
using HR_Management.WebMvc.Cantracts;
using HR_Management.WebMvc.Models.LeaveType;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel createLeaveTypeVm)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(createLeaveTypeVm);

                AddBearerToken();

                var apiResponse = await _httpClient.LeaveTypePOSTAsync(createLeaveTypeDto);

                if (apiResponse.IsSuccess)
                {
                    response.Data = apiResponse.Id;
                    response.IsSuccess = true;
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
            catch (ApiException ex)
            {

                return ConvertApiException<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                var response = new Response<int>();
                AddBearerToken();
                await _httpClient.LeaveTypeDELETEAsync(id);
                response.IsSuccess = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiException<int>(ex);
            }
        }

        public async Task<UpdateLeaveTypeViewModel> GetLeaveTypeForUpdate(int id)
        {
            AddBearerToken();
            var leaveType = await _httpClient.LeaveTypeGETAsync(id);
            return _mapper.Map<UpdateLeaveTypeViewModel>(leaveType);
        }

        public async Task<LeaveTypeViewModel> GetLeaveTypesBy(int id)
        {
            AddBearerToken();
            var leaveType = await _httpClient.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeViewModel>(leaveType);
        }

        public async Task<List<LeaveTypeViewModel>> GetLeaveTypesList()
        {
            AddBearerToken();
            var leaveTypes = await _httpClient.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(UpdateLeaveTypeViewModel updateLeaveTypeVm)
        {
            try
            {
                var response = new Response<int>();

                var updateLeaveTypeDto = _mapper.Map<UpdateLeaveTypeDto>(updateLeaveTypeVm);
                AddBearerToken();
                await _httpClient.LeaveTypePUTAsync(updateLeaveTypeVm.Id, updateLeaveTypeDto);

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
