﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VactionApi.Dtos
{
    public class EmpForLoginDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Username can't be Empty")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
