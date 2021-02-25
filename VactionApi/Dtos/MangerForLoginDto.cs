using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VactionApi.Dtos
{
    public class MangerForLoginDto
    {
        [Required(ErrorMessage = "Username can't be Empty")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
