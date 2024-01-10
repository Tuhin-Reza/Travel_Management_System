using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class LeaveSheet
    {
        [Key]
        public int Id { get; set; }
        public DateTime Month { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int Sick { get; set; }
        public int Vacation { get; set; }
        public int Personal { get; set; }
        public int Marriage { get; set; }
        public int TotalLeave { get; set; }
    }
}
