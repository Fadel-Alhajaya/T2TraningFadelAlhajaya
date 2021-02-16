using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vacation_System.Models
{
    public class Manger
    {
            public int Id { get; set; }
            public string Username { get; set; }
           public string Password { get; set; }

           public ICollection<Employee> Employees;
        public ICollection<Vacation> Vacationss  { get; set; }
    }
    }

