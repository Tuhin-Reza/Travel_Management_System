using System;

namespace BLL.DTOS
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Status { get; set; }
        public int EmplTypeId { get; set; }
    }
}
