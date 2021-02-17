using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vacation_System.Models;
using VactionApi.Data;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsRequestsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepositry _repo;

        public VacationsRequestsController(IRepositry repo, DataContext context)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/VacationsRequests
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetsingelVactionss(int id)
        {
            if (await _context.Vactionss.AnyAsync(x => x.EmpID == id)) 
            {
                var td = (from V in _context.Vactionss
                          join Emp in _context.Employeess on id equals Emp.ID
                          where
                          V.EmpID == Emp.ID
                          select new
                          {
                             V.id,
                             V.VactionDate,
                             V.Type,
                             V.Description,
                             V.EmpID
                          }).ToList();

                return Ok(td);
            }
            return Unauthorized();
        }
    

        
        [HttpGet]
        public async Task<IActionResult> GetAllVacations()
        {
            var AllVactions = await _context.Vactionss.ToListAsync();

            return Ok(AllVactions);
        }

       
        
    }
}