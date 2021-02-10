﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacation_System.Models;

namespace VactionApi.Data
{
    public  interface IRepositry
    {
        Task<Manger> RegisterForManger(Manger M );
        Task<Manger> LoginForManger(string username,int id);
        Task<Employee> Register(Employee E);
        Task<Employee> Login(string username, string password);

        Task<bool> UserExists(string username);




        

    }
}