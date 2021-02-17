using System;

namespace vacation_System.Models
{
    public class Vacation
    {
        public int id { get; set; }
        public string Type { get; set; }
        public DateTime VactionDate { get; set; }
        public string Description { get; set; }
        public Employee Employees { get; set; }
        public int EmpID { get; set; }

    }
}