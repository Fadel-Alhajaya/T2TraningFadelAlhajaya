using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MangerAuthController : ControllerBase
    {
        private readonly IRepositry _repo;
        private readonly DataContext _context;

        public MangerAuthController(IRepositry repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }
        // GET: api/MangerAuth
        [HttpGet("MangerRegister")]
        public async Task<IActionResult> RegisterManger(string username)
        {
            username = username.ToLower();
            var Mangers = await _context.Managerss.AnyAsync(x => x.Username == username);
            if(Mangers)
            {
                return BadRequest("Employee is already Registerd");
            }

            var MangerCreate = new Manger
            {
                Username = username,

            };
            var CreatedMan = await _repo.RegisterForManger(MangerCreate);

            return Ok(CreatedMan);
        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(string username, int id)
        {

            var MangerFrorepo = await _repo.LoginForManger(username.ToLower(), id );


            if (MangerFrorepo == null)
            {
                return Unauthorized();
            }
            var Mangers = await _context.Managerss.AnyAsync(x => x.Id == id);
            if (Mangers)
            {
                return BadRequest("manger is already Registerd");
            }
            
            return Ok(MangerFrorepo);
        }
    }
}
