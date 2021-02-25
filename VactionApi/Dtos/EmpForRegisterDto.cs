using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VactionApi.Dtos
{
    public class EmpForRegisterDto
    {
        [Required(ErrorMessage = " Your Username can't be Empty")]
        public string Username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Your Password is not valid")]
        public string Password { get; set; }
        public string JobNumber { get; set; }
        public string BirthDate { get; set; }
    }
}
