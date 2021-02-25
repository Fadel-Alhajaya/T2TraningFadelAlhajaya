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
using VactionApi.Dtos;

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
        public async Task<IActionResult> RegisterManger(MangerForRegisterDto manger)
        {
            manger.Username = manger.Username.ToLower();
            //casting object because entityExist take manger object 
            var m = new Manger { Username = manger.Username };
            if (await _repo.EntityExists(m))
            {
                return BadRequest("Manger is already Exists");
            }
            var manCreate = new Manger
            {
                Username = manger.Username,
                Password = manger.Password,
                BirthDate= manger.BirthDate,
                JobNumber= manger.JobNumber
              
            };
            var createdManger = await _repo.AddEntity(manCreate);

            return Ok(createdManger);
           
        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(MangerForLoginDto manger)
        {
            var m = new Manger { Username = manger.Username,Password=manger.Password };
            var logMangerr = await _repo.FindEntity(m);
            if (logMangerr == null)
            {
                return BadRequest("The login is incorrect Your username or password is wrong ");
            }    
            return Ok(logMangerr);


        }
    }
}
