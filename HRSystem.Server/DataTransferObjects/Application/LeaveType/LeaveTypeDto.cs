namespace HRSystem.Server.DataTransferObjects.Application.LeaveType
{
    public record LeaveTypeDto
    {
        public int LeaveTypeId { get; init; }

        public string LeaveName { get; init; } = null!;

       
    }



}
