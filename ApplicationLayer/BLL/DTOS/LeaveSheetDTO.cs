using System;

namespace BLL.DTOS
{
    public class LeaveSheetDTO
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int Sick { get; set; }
        public int Vacation { get; set; }
        public int Personal { get; set; }
        public int Marriage { get; set; }
        public int TotalLeave { get; set; }
    }
}
