using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VactionApi.Dtos
{
    public class VactionDto
    {
        public int Id { get; set; }
        [Required( ErrorMessage = "The Type of Vactions is Required ")]
        public string Type { get; set; }
        [Required(ErrorMessage = "The Date of Vactions is Required ")]
        public DateTime VactionDate { get; set; }
        [Required(ErrorMessage = "The Date of Vactions is Required ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Employee ID of Vactions is Required ")]
        public int EmpID { get; set; }
    }
}
