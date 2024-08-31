using AutoMapper;
using HR_Management.WebMvc.Models.LeaveAllocation;
using HR_Management.WebMvc.Models.LeaveRequest;
using HR_Management.WebMvc.Models.LeaveType;
using HR_Management.WebMvc.Services.Base;

namespace HR_Management.WebMvc.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeViewModel>().ReverseMap();
            CreateMap<UpdateLeaveTypeDto, UpdateLeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveTypeDto, UpdateLeaveTypeViewModel>().ReverseMap();

            CreateMap<LeaveAllocationDto, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<CreateLeaveAllocationDto, CreateLeaveAllocationViewModel>().ReverseMap();
            CreateMap<UpdateLeaveAllocationDto, UpdateLeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocationDto, UpdateLeaveAllocationViewModel>().ReverseMap();

            CreateMap<LeaveRequestListDto, LeaveRequestListViewModel>().ReverseMap();
            CreateMap<LeaveRequestDto, LeaveRequestViewModel>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, CreateLeaveRequestViewModel>().ReverseMap();
            CreateMap<UpdateLeaveRequestDto, UpdateLeaveRequestViewModel>().ReverseMap();
            CreateMap<LeaveRequestDto, UpdateLeaveRequestViewModel>().ReverseMap();

            CreateMap<DateTimeOffset, DateTime>().ConvertUsing(datetimeoffset => datetimeoffset.DateTime);
        }
    }
}
