using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vacation_System.Models;
using VactionApi.Data;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorePolicy")]
    public class VacationsRequestsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepositry _repo;

        public VacationsRequestsController(IRepositry repo, DataContext context)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/VacationsRequests/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetsingelVactionss(int id)
        {
            if (await _context.Employeess.AnyAsync(x => x.ID == id))
            {
                var td = (from V in _context.Vactionss
                          join Emp in _context.Employeess on id equals Emp.ID
                          where
                          V.EmpID == Emp.ID
                          select new
                          {
                              V.Id,
                              V.VactionDate,
                              V.Type,
                              V.Description,
                              V.EmpID
                          }).ToList();

                return Ok(td);
            }
            return Unauthorized();
        }


        // GET: api/VacationsRequests

        [HttpGet("allvaction")]
        public async Task<IActionResult> GetAllVacations()
        {
            var AllVactions = await _context.Vactionss.ToListAsync();

            return Ok(AllVactions);
        }
        [HttpPost]
        [Route("add_vactions")]
        public async Task<IActionResult> AddVactions(Vacation V)
        {

            if (await _context.Employeess.AnyAsync(x => x.ID == V.EmpID))
            {


                if (V.Employees.Status == true && V.Employees.Vacations <= 16)
                {
                    var CreateVaction = new Vacation
                    {

                        Type = V.Type,
                        VactionDate = V.VactionDate,
                        Description = V.Description,
                        EmpID = V.EmpID,

                    };

                    var InsertVaction = await _repo.AddVaction(CreateVaction);

                    return Ok(new { InsertVaction = "Vaction added!" });
                }
            }
            else
            {
                return BadRequest("Vaction is not Vaild ");
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("update_Vactions/{id}")]
        public async Task< IActionResult> UpdateVaction(Vacation V, int id)
        {

            if ( await _context.Employeess.AnyAsync(x => x.ID == id))
            {
                var entity =  _context.Vactionss.FirstOrDefault(item => item.Id == V.Id);

                if (entity != null)
                {
                       
                        entity.Type = V.Type;
                        entity.VactionDate = V.VactionDate;
                        entity.Description = V.Description;


                    _context.Vactionss.Update(entity);
                    await _context.SaveChangesAsync();
                    return Ok("Your Vaction have updated");
                    }
                    else
                    {
                        return BadRequest("Error in Process");
                    }
                   
                }
            return Unauthorized();

        
           
        }
    }
}
        
    
