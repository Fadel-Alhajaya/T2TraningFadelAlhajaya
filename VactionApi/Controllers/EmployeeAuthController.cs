using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vacation_System.Models;
using VactionApi.Data;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly IRepositry _repo;

        public EmployeeAuthController( IRepositry repo)
        {
            _repo = repo;      
        }
        // GET: api/EmployeeAuth
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
            
        //}

        // GET: api/EmployeeAuth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmployeeAuth
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username)
        {
            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Employee is already Exists");

            var EmpCreate = new Employee
            {
                Username = username,

            };
            var CreatedEmp = await _repo.Register(EmpCreate);

            return Ok(CreatedEmp);
        }

        // PUT: api/EmployeeAuth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
