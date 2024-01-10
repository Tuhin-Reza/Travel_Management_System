using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class LeaveType
    {
        public LeaveType()
        {
            this.LeaveRequests = new HashSet<LeaveRequest>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string LeaveTypeName { get; set; }

        [Required]
        public int TotalDays { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
