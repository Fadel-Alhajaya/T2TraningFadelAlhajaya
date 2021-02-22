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

        private readonly IRepositry<Vacation> _repo;
        private readonly DataContext _context;

        public VacationsRequestsController(IRepositry<Vacation> repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        // GET: api/VacationsRequests/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetsingelVactionss(int id)
        {
            if (await _context.Vactionss.AnyAsync(x => x.Id == id))
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
                return Ok();

            }
           
            return Unauthorized();
        }


        // GET: api/VacationsRequests

        [HttpGet("allvaction")]
        public async Task<IActionResult> GetAllVacations()
        {
            var AllVactions = await _repo.GetAllEntity();

            return Ok(AllVactions);
        }
        [HttpPost]
        [Route("add_vactions")]
        public async Task<IActionResult> AddVactions(Vacation v)
        {

            if (await _repo.CheckEntity(v,v.EmpID))
            {
                    var createVaction = new Vacation
                    {

                        Type = v.Type,
                        VactionDate = v.VactionDate,
                        Description = v.Description,
                        EmpID = v.EmpID,

                    };

                    var insertVaction = await _repo.AddEntity(createVaction);

                    return Ok(new { insertVaction = "Vaction added!" });

            }
            else
            {
                return BadRequest("Vaction is not Vaild ");
            }
           
        }
        [HttpPost]
        [Route("update_Vactions/{id}")]
        public async Task<IActionResult> UpdateVaction(Vacation v, int id)
        {

            if (await _repo.CheckEntity(v, id))
            {
                var entity = _repo.FindEntity(v);

                if (entity != null)
                {
                    await _repo.Update(v);
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
        
    
