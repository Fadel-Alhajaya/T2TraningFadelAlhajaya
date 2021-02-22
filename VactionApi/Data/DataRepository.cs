using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public class DataRepository : IRepositry<Manger>
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }

       
        public  async Task<Manger> AddEntity(Manger T)
        {
            await _context.Managerss.AddAsync(T);
            await _context.SaveChangesAsync();

            return T;
        }


        public async Task<bool> EntityExists(Manger m)
        {
            if (await _context.Managerss.AnyAsync(x => x.Username== m.Username))
            {
                return true;
            }

            return false;
        }

        public async Task<Manger> FindEntity(Manger t)
        {
            if (await EntityExists(t))
                return t;
            else
                return null;
        }

        public async Task<bool> CheckEntity(Manger t,int id)
        {
            var manger = await _context.Managerss.FirstOrDefaultAsync(x => x.Id == id);
            if (manger.Password==t.Password)

                  return true;

            return false;
            

        }

        public async Task<bool> GetEntity(int id)
        {
            if (await _context.Managerss.AnyAsync(x => x.Id == id))
            {
                return true;
            }

            return false;
        }

        public async Task<IList<Manger>> GetAllEntity()
        {
            return  await _context.Managerss.ToListAsync(); 
        }

        public async Task Update(Manger m)
        {
            _context.Managerss.Update(m);
            await _context.SaveChangesAsync();
        }

        public async  Task<int> DeleteProduct(int myID)
        {
            int result = 0;
            var getmanger = await _context.Managerss.FirstOrDefaultAsync(x => x.Id == myID);
            if (getmanger != null)
            {
                _context.Managerss.Remove(getmanger);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}

