using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vacation_System.Models
{
    public class Employee
    {
 
        public int ID { get; set; }
        
        public string Username { get; set; }
        
        public string Password  { get; set; }
        public string JobNumber { get; set; }
        public string BirthDate { get; set; }
        public int Vacations { get; set; }

        public bool Status { get; set; }

        public ICollection<Vacation> Vacation { get; set; }

        public Manger EmpManger { get; set; }
        public int MangerID { get; set; }




    }

    
}

