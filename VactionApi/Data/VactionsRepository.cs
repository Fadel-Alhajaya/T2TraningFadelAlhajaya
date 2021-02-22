using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public class VactionsRepository : IRepositry<Vacation>
    {
        private readonly DataContext _context;

        public VactionsRepository(DataContext context)
        {
            _context = context;
        }
        public  async Task<Vacation> AddEntity(Vacation v)
        {
            await _context.Vactionss.AddAsync(v);
            await _context.SaveChangesAsync();
            return v;
        }

       

        public async Task<bool> CheckEntity(Vacation  t, int id)
        {
            if (await _context.Employeess.AnyAsync(x => x.ID == t.EmpID))
            {
                Employee emp = await _context.Employeess.FirstOrDefaultAsync(x => x.ID == t.EmpID);
                if (emp.Status == true && emp.Vacations <= 16)
                    return true;
            }


            return false;
        }

        public  async Task<int> DeleteProduct(int myID)
        {
            int result = 0;
            var getvaction = await _context.Vactionss.FirstOrDefaultAsync(x => x.Id == myID);
            if (getvaction != null)
            {
                _context.Vactionss.Remove(getvaction);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public  async Task<bool> EntityExists(Vacation v)
        {
            if (await _context.Vactionss.AnyAsync(x => x.Id == v.Id ))
            {
                return true;
            }

            return false;
        }

        public async Task<Vacation> FindEntity(Vacation v)
        {
            if (await EntityExists(v))
                return v;
            else
                return null;
        }

        public async Task<IList<Vacation>> GetAllEntity()
        {
            return await _context.Vactionss.ToListAsync();
        }

        public async Task<bool> GetEntity(int id)
        {
            if (await _context.Vactionss.AnyAsync(x => x.Id == id))
            {
                return true;
            }

            return false;
        }
            
                

        public async Task  Update(Vacation v)
        {
            _context.Vactionss.Update(v);
            await _context.SaveChangesAsync();
        }

        //public async Task< IList > FindEmployee(int id )
        //{
        //    if (await _context.Vactionss.AnyAsync(x => x.EmpID == id))
        //    {
        //        var td = (from V in _context.Vactionss
        //                  join Emp in _context.Employeess on id equals Emp.ID
        //                  where
        //                  V.EmpID == Emp.ID
        //                  select new
        //                  {
        //                      V.Id,
        //                      V.VactionDate,
        //                      V.Type,
        //                      V.Description,
        //                      V.EmpID
        //                  }).ToListAsync();
        //        return  td;

        //    }
            
    }
}

