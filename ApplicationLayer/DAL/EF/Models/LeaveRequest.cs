using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LeaveStartDate { get; set; }

        [Required]
        public DateTime LeaveEndDate { get; set; }

        [Required]
        public int TotalDays { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("LeaveType")]
        public int LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
