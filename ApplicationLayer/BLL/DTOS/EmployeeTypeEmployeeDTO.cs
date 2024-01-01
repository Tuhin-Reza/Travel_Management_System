using System.Collections.Generic;

namespace BLL.DTOS
{
    public class EmployeeTypeEmployeeDTO : EmployeeTypeDTO
    {
        //public List<EM> Courses { get; set; }
        //public DepartmentCourseDTO()
        //{
        //    Courses = new List<CourseDTO>();
        //}

        public List<EmployeeDTO> Employees { get; set; }
        public EmployeeTypeEmployeeDTO()
        {
            Employees = new List<EmployeeDTO>();
        }
    }
}
