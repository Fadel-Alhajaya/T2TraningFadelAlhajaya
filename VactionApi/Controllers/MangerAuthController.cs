using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using vacation_System.Models;
using VactionApi.Data;
using VactionApi.Dtos;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorePolicy")]
    public class MangerAuthController : ControllerBase
    {
        private readonly IRepositry<Manger> _repo;
        private readonly IConfiguration _config;

        public MangerAuthController(IRepositry<Manger> repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        // Post: api/MangerAuth
        [HttpPost("MangerRegister")]
        public async Task<IActionResult> RegisterManger(MangerForRegisterDto manger)
        {
            manger.Username = manger.Username.ToLower();
            //casting object because entityExist take manger object 
            var m = new Manger { Username = manger.Username };
            var manger1 = await _repo.FirstOrDefault(x => x.Username == m.Username);
            if (manger1 != null)
            {
                return BadRequest("Manger is already Exists");
            }
            var manCreate = new Manger
            {
                Username = manger.Username,
                Password = manger.Password,
                BirthDate = manger.BirthDate,
                JobNumber = manger.JobNumber

            };
            var createdManger = await _repo.Create(manCreate);

            var clamis = new[]
             {
                new Claim (ClaimTypes.NameIdentifier,createdManger.Id.ToString()),
                new Claim (ClaimTypes.Name,createdManger.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clamis),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                uInfo = createdManger
            });

        }
        [HttpPost("MangerLogin")]
        public async Task<IActionResult> LoginForManger(MangerForLoginDto manger)
        {
            var m = new Manger { Username = manger.Username, Password = manger.Password };
            var logMangerr = await _repo.FirstOrDefault(x=>x.Username== m.Username && x.Password== m.Password);
            if (logMangerr == null)
            {
                return Unauthorized();
            }
            var clamis = new[]
           {
                new Claim (ClaimTypes.NameIdentifier,logMangerr.Id.ToString()),
                new Claim (ClaimTypes.Name,logMangerr.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clamis),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
            });


        }
    }
}
