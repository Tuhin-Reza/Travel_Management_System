using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TKey { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Expired { get; set; }


        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
