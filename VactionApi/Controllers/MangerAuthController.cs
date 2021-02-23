using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MangerAuthController : ControllerBase
    {
        private readonly IRepositry<Manger> _repo;
        private readonly DataContext _context;

        public MangerAuthController(IRepositry<Manger> repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }
        // Post: api/MangerAuth
        [HttpPost("MangerRegister")]
        public async Task<IActionResult> RegisterManger(Manger M)
        {
            M.Username = M.Username.ToLower();
            if (await _repo.EntityExists(M))
            {
                return BadRequest("Manger is already Exists");
            }
            var manCreate = new Manger
            {
                Username = M.Username,
                Password = M.Password,
                BirthDate=M.BirthDate,
                JobNumber=M.JobNumber
              
            };
            var createdMan = await _repo.AddEntity(manCreate);

            return Ok(createdMan);
           
        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(Manger m)
        {
            if (m == null)
                return BadRequest("Manger is null");

            var Mangerr = await _repo.FindEntity(m);
            if (Mangerr == null)
            {
                return BadRequest("The login is incorrect");
            }    
            return Ok(Mangerr);


        }
    }
}
