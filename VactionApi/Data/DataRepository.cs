﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public class DataRepository : IRepositry
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }
        public Task<Employee> Login(string username, string password)
        {
            var Emp = _context.Employeess.FirstOrDefaultAsync(x => x.Username == username);
            var pass= _context.Employeess.FirstOrDefaultAsync(x => x.Password == password);
            if (Emp == null && pass == null)
            {
                return null;
                
            }
            return Emp;

        }

        public Task<Manger> LoginForManger(string username, int id)
        {
            var manger = _context.Managerss.FirstOrDefaultAsync(x => x.Username == username);
            var pass = _context.Managerss.FirstOrDefaultAsync(x => x.Id == id);
            if (manger == null && pass == null)
            {
                return null;

            }
            return manger;

        }

        public async Task<Employee> Register(Employee E)
        {
            await _context.Employeess.AddAsync(E);
            await _context.SaveChangesAsync();

            return E;
        }

        public async Task<Manger> RegisterForManger(Manger M)
        {
            await _context.Managerss.AddAsync(M);
            await _context.SaveChangesAsync();

            return M;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Employeess.AnyAsync(x => x.Username == username))
                {
                return true;
                 }
           
           return false;
        }
    }
}