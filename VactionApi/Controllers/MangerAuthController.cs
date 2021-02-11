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
        // Post: api/MangerAuth
        [HttpPost("MangerRegister")]
        public async Task<IActionResult> RegisterManger(Manger M)
        {
           M.Username  = M.Username.ToLower();
            

            var Mangers = await _context.Managerss.AnyAsync(x => x.Username == M.Username.ToLower());
            if(Mangers)
            {
                return BadRequest("Manger is already Registerd");
            }

            var MangerCreate = new Manger
            {
                Username = M.Username,
            };
            var CreatedMan = await _repo.RegisterForManger(MangerCreate);

            return Ok(CreatedMan);
        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(Manger m)
        {
            if (m == null)
                return BadRequest("Manger is null");
            var MangerFrorepo = await _repo.LoginForManger(m.Username.ToLower(), m.Id );


            if (MangerFrorepo == null)
            {
                return Unauthorized();
            }
            return Ok(MangerFrorepo);
            //var Mangers = await _context.Managerss.AnyAsync(x => x.Id ==m.Id);
            //if (Mangers)
            //{
            //    return BadRequest("manger is already Registerd");
            //}


        }
    }
}
