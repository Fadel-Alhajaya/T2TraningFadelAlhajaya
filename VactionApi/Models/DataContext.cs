using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace vacation_System.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


       
        public DbSet<Employee> Employeess { get; set; }
        public DbSet<Manger> Managerss { get; set; }
    }
}
