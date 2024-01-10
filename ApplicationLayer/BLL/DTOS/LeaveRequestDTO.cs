using System;

namespace BLL.DTOS
{
    public class LeaveRequestDTO
    {
        public int Id { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int TotalDays { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
