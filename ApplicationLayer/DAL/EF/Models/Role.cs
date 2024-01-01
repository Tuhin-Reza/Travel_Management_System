using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
