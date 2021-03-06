using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using vacation_System.Models;

using VactionApi.Data;
using VactionApi.Dtos;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorePolicy")]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly IRepositry<Employee> _repo;
        private readonly IConfiguration _config;

        public EmployeeAuthController(IRepositry<Employee> repo , IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        //  GET: api/EmployeeAuth/
        [HttpGet("get")]
        public string Get()
        {
            return "value";
        }

        // POST: api/EmployeeAuth
        [HttpPost("register")]
        public async Task<IActionResult> Register(  EmpForRegisterDto emp)
        {
            emp.Username = emp.Username.ToLower();
            //temp object beacuse entityExist take employee object not dto
            var e = new Employee { Username = emp.Username };
            if (await _repo.EntityExists(e))
            {
                return  BadRequest("Employee is already Exists");
            }
            var empCreate = new Employee
            {
                Username = emp.Username,
                Password = emp.Password,
                BirthDate=emp.BirthDate,
                JobNumber=emp.JobNumber,
                MangerID = 1,
                Vacations = 16,
                Status = true

            };
            var createdEmp = await _repo.AddEntity(empCreate);

            return StatusCode(201);
        }

        [HttpPost("employeeLogin")]
        public async Task<IActionResult> LoginForEmployee(EmpForLoginDto emp)
        {
           
            //temp object beacuse entityExist take employee object not dto
            var empTemp = new Employee { Username = emp.Username, Password = emp.Password };
            var employee = await _repo.FindEntity(empTemp);
            if (employee == null)
            {
                return Unauthorized();
            }

            var clamis = new[]
            {
                new Claim (ClaimTypes.NameIdentifier,emp.ID.ToString()),
                new Claim (ClaimTypes.Name,emp.Username)
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
    
        [AllowAnonymous]
        [HttpGet("getEmployee")]
        public async Task< IEnumerable> GetEmployee()
        {
            return await _repo.GetAllEntity();
        }
        //[AllowAnonymous]
        //[HttpPut]
        //[Route("update_employee/{id}")]
        //public async Task<IActionResult> UpdateEmployee( EmployeeForUpdateDto emp)
        //{
        //    Employee newEmployee = new Employee { ID = emp.ID, Username = emp.Username, Password = emp.Password, BirthDate = emp.BirthDate, JobNumber = emp.JobNumber  };
        //    //temp object of Employee beacuse Get take Emplyee object 
        //    var Entity = _repo.GetEntity(newEmployee.ID);
        //    if (Entity != null)
        //    {
            
        //        await _repo.Update(newEmployee);
        //        return Ok("Your Employee Info have updated");
        //    }
        //    else
        //    {
        //        return BadRequest("Error in Process of Update");
        //    }
           
        //}

        
        [HttpDelete]
        [Route("delete_Employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            int flag = await _repo.DeleteEntity(id);
            if (flag == 0)
                return BadRequest("error in the Delete proccess");


            return Ok("The Employee successfully Deleted");


        }
    }
}

