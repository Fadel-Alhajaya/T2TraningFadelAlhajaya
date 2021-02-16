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
        private readonly IRepositry _repo;
        private readonly DataContext _context;

        public MangerAuthController(IRepositry repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }
        // Post: api/MangerAuth
        [HttpPost("MangerRegister")]
        public async Task<IActionResult> RegisterManger(Manger M)
        {
            M.Username = M.Username.ToLower();
            if (await _repo.MangerExists(M.Username))
            {
                return BadRequest("Manger is already Exists");
            }
            var ManCreate = new Manger
            {
                Username = M.Username,
                Password = M.Password,
              
            };
            var CreatedMan = await _repo.RegisterForManger(ManCreate);

            return Ok(CreatedMan);
           
        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(Manger m)
        {
            if (m == null)
                return BadRequest("Manger is null");

            var Mangerr = await _repo.LoginForManger(m.Username,m.Password);


            if (Mangerr == null)
            {
                return Unauthorized();
            }
            return Ok(Mangerr); 
          

        }
    }
}
