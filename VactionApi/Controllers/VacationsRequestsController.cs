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
            var vaction = await _repo.FirstOrDefault(e => e.Id == id);
            if (vaction != null)
            {
                return Ok(vaction);
            }
            else
                return BadRequest("the Id number have not  any Vactions");


    }


        // GET: api/VacationsRequests

        [HttpGet("allvaction")]
        public async Task<IActionResult> GetAllVacations()
        {
            var AllVactions = await _repo.List();

            return Ok(AllVactions);
        }

        [HttpPost]
        [Route("add_vactions")]
        public async Task<IActionResult> AddVactions([FromBody] VactionDto v)
        {
            //temp object of vaction beacuse findEntity take Vaction object 
            //var Vac = new Vacation { EmpID = v.EmpID };

            //var newVaction = await _repo.FirstOrDefault(x => x.Employees.ID == Vac.EmpID);
            if (v != null)
            {
                var createVaction = new Vacation
                {

                    Type = v.Type,
                    VactionDate = v.VactionDate,
                    Description = v.Description,
                    EmpID = v.EmpID,

                };

                var insertVaction = await _repo.Create(createVaction);

                return Ok(new { insertVaction = "Vaction are added!" });
            }
            return BadRequest(" error in vaction proccess");
            }

        [HttpPut]
        [Route("update_Vactions/{id}")]
        public async Task<IActionResult> UpdateVaction(VactionDto v, int id)
        {
            //temp object of vaction beacuse findEntity take Vaction object 
            var newVaction = new Vacation {EmpID = v.EmpID, Description = v.Description, Type = v.Type, VactionDate = v.VactionDate };
            var entity = await _repo.Find(x => x.Id == id);
            if (entity != null)
            {
                entity.Type = v.Type;
                entity.Description = v.Description;
                entity.VactionDate = v.VactionDate;

                await _repo.Update(entity);
                return Ok("Your Vaction is updated");

            }
            return BadRequest("Error in Process of Update");
            
        }



        [HttpDelete]
        [Route("delete_Vactions/{id}")]
        public async Task<IActionResult> DeleteVaction(int id)
        {
            Vacation entity = await _repo.FirstOrDefault(x => x.Id == id);
            int flag = await _repo.DeleteEntity(entity);
            if (flag == 0)
                return BadRequest("error in the Delete proccess");


            return Ok("The Vaction successfully Deleted");


        }

    }
}
        
    
