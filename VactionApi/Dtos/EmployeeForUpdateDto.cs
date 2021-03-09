using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VactionApi.Dtos
{
    public class EmployeeForUpdateDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobNumber { get; set; }
        public string BirthDate { get; set; }
        public int MangerID { get; set; }

    }
}
