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
using VactionApi.Dtos;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorePolicy")]
    public class VacationsRequestsController : ControllerBase
    {

        private readonly IRepositry<Vacation> _repo;
        private DataContext _context;

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
            if (await _context.Vactionss.AnyAsync(x => x.EmpID == id))
            {
                var td = (from v in _context.Vactionss
                          join emp in _context.Employeess on id equals emp.ID
                          where
                          v.EmpID == emp.ID
                          select new
                          {
                              v.Id,
                              v.VactionDate,
                              v.Type,
                              v.Description,
                              v.EmpID
                          }).ToList();
                return Ok(td);

            }
            else
                return BadRequest("the Id number have not  any Vactions");
           

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
        public async Task<IActionResult> AddVactions( [FromBody]VactionDto v)
        {
            //temp object of vaction beacuse findEntity take Vaction object 
            var Vac = new Vacation { EmpID = v.EmpID };

            var newVaction = await _repo.FindEntity(Vac);
            if (newVaction != null)
            {
                var createVaction = new Vacation
                {

                    Type = newVaction.Type,
                    VactionDate = newVaction.VactionDate,
                    Description = newVaction.Description,
                    EmpID = newVaction.EmpID,

                };

                var insertVaction = await _repo.AddEntity(createVaction);

                return Ok(new { insertVaction = "Vaction are added!" });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("update_Vactions/{id}")]
        public async Task<IActionResult> UpdateVaction(VactionDto v)
        {
            //temp object of vaction beacuse findEntity take Vaction object 
            var newVaction = new Vacation { Id = v.Id, EmpID = v.EmpID ,Description=v.Description,Type=v.Type,VactionDate=v.VactionDate};
            if ( await _repo.EntityExists(newVaction))
            { 
            
                var entity =  await _repo.FindEntity(newVaction);

                if (entity != null)
                {
                    await _repo.Update(newVaction);
                    return Ok("Your Vaction have updated");
                }
                else
                {
                    return BadRequest("Error in Process of Update");
                }

            }
            return Unauthorized();

        }
        [HttpDelete]
        [Route("delete_Vactions/{id}")]
        public async Task<IActionResult> DeleteVaction(int id)
        {
            int flag = await _repo.DeleteEntity(id);
            if (flag == 0)
                return BadRequest("error in the Delete proccess");


          return Ok("The Vaction successfully Deleted");


        }

        }
    }
        
    
