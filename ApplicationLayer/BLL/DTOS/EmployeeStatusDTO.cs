using System.ComponentModel.DataAnnotations;

namespace BLL.DTOS
{
    public class EmployeeStatusDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Status { get; set; }

    }
}
