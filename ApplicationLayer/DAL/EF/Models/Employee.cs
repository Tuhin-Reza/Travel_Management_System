﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Employee
    {
        public Employee()
        {
            this.LeaveRequests = new List<LeaveRequest>();
            this.LeaveSheets = new List<LeaveSheet>();
            this.EmployeeSalaries = new List<EmployeeSalary>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PresentAddress { get; set; }

        [Required]
        public string PermanentAddress { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Status { get; set; }


        [ForeignKey("EmployeeType")]
        public int EmplTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }


        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public ICollection<LeaveSheet> LeaveSheets { get; set; }
        public ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
    }
}
