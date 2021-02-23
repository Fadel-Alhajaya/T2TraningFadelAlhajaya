using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public class EmployeeRepository:IRepositry<Employee>
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEntity(Employee e)
        {
            await _context.Employeess.AddAsync(e);
            await _context.SaveChangesAsync();

            return e;
        }

      

        public async Task<int> DeleteEntity(int myID)
        {
            int result = 0;
            var getemployee = await _context.Employeess.FirstOrDefaultAsync(x => x.ID == myID);
            if (getemployee != null)
            {
                _context.Employeess.Remove(getemployee);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<bool> EntityExists(Employee e)
        {
            if (await _context.Employeess.AnyAsync(x => x.Username == e.Username))
                return true;
            

            return false;
        }

        public  async Task<Employee> FindEntity(Employee e)
        {
            
            if (await EntityExists(e))
            {

                var employee = _context.Employeess.FirstOrDefault(x => x.Username == e.Username );
                if (e.Password != employee.Password)
                    return null;
                else
                    return employee;
            }

            else
                return null;
        }

        public async Task<IList<Employee>> GetAllEntity()
        {
            return await _context.Employeess.ToListAsync();
        }

        public Employee GetEntity(int id)
        {
                var employee = _context.Employeess.FirstOrDefault(x => x.ID == id);
                return employee;
            

            
        }

        public async Task Update(Employee e)
        {
            _context.Employeess.Update(e);
            await _context.SaveChangesAsync();
        }
    }
}
