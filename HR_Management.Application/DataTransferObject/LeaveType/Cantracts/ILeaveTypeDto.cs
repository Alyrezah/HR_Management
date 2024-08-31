namespace HR_Management.Application.DataTransferObject.LeaveType.Cantracts
{
    public interface ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
