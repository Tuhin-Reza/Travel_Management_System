using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOS
{
    public class TokenDTO
    {

        [Required]
        [StringLength(100)]
        public string TKey { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        public DateTime? ExpiredTime { get; set; }
        public string UserId { get; set; }
    }
}
