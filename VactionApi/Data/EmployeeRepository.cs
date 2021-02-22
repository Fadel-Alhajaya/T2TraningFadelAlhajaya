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

        public async Task<bool> CheckEntity(Employee e, int id)
        {
            var emp = await _context.Employeess.FirstOrDefaultAsync(x => x.ID == id);
            if (e.Password!=emp.Password)
                return false;

            return true;
        }

        public async Task<int> DeleteProduct(int myID)
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
                return e;
            else
                return null;
        }

        public async Task<IList<Employee>> GetAllEntity()
        {
            return await _context.Employeess.ToListAsync();
        }

        public async Task<bool> GetEntity(int id)
        {
            if (await _context.Employeess.AnyAsync(x => x.ID== id))
            {
                return true;
            }

            return false;
        }

        public async Task Update(Employee e)
        {
            _context.Employeess.Update(e);
            await _context.SaveChangesAsync();
        }
    }
}
