using AutoMapper;
using HR_Management.Application.DataTransferObject.LeaveAllocation;
using HR_Management.Application.DataTransferObject.LeaveRequest;
using HR_Management.Application.DataTransferObject.LeaveType;
using HR_Management.Domain;

namespace HR_Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveAllocation

            CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation,CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            #endregion

            #region LeaveType Mapping

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();

            #endregion

            #region LeaveRequest Mapping

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();

            #endregion
        }
    }
}
