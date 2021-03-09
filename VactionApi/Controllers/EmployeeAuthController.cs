using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorePolicy")]


    public class EmployeeAuthController : ControllerBase
    {
        private readonly IRepositry<Employee> _repo;
        private readonly IConfiguration _config;

        public EmployeeAuthController(IRepositry<Employee> repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        //  GET: api/EmployeeAuth/
        [AllowAnonymous]
        [HttpGet("GetSingelEmployee/{id}")]
        public async Task<IActionResult> GetSingelEmployeeAsync(int id)
        {
            var employee = await _repo.FirstOrDefault(e => e.ID == id);
            return Ok(employee);
        }

        // POST: api/EmployeeAuth
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(EmpForRegisterDto emp)
        {
            emp.Username = emp.Username.ToLower();
            //temp object beacuse entityExist take employee object not dto
            var e = new Employee { Username = emp.Username };
            Expression<Func<Employee, bool>> expression = u => u.Username == emp.Username;
            var getUser = await _repo.FirstOrDefault(expression);
            if (getUser != null)
            {
                return BadRequest("Employee is already Exists");
            }
            var empCreate = new Employee
            {
                Username = emp.Username,
                Password = emp.Password,
                BirthDate = emp.BirthDate,
                JobNumber = emp.JobNumber,
                MangerID = 1,
                Vacations = 16,
                Status = true

            };
            var createdEmp = await _repo.Create(empCreate);
            var clamis = new[]
            {
                new Claim (ClaimTypes.NameIdentifier,createdEmp.ID.ToString()),
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
                uInfo = getUser
            });
        }


    
        [AllowAnonymous]
        [HttpPost("employeeLogin")]
        public async Task<IActionResult> LoginForEmployee(EmpForLoginDto emp)
        {

            //temp object beacuse entityExist take employee object not dto
            var empTemp = new Employee { Username = emp.Username, Password = emp.Password };
            var employee = await _repo.Find(x=> x.Username==empTemp.Username && x.Password== empTemp.Password);
            if (employee == null)
            {
                return Unauthorized();
            }

            var clamis = new[]
            {
                    new Claim (ClaimTypes.NameIdentifier,employee.ID.ToString()),
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
        public async Task<IEnumerable> GetAllEmployee()
        {
            List<Employee> employees =  await _repo.List();
            return employees;
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update_employee/{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeForUpdateDto emp, int id)
        {
            Employee newEmployee = new Employee {  Username = emp.Username, Password = emp.Password, BirthDate = emp.BirthDate, JobNumber = emp.JobNumber , MangerID = emp.MangerID };
            //temp object of Employee beacuse Get take Emplyee object 
            var Entity =  await _repo.FirstOrDefault(x=>x.ID == id);
            if (Entity != null)
            {
                
                await _repo.Update(newEmployee);
                return Ok("Your Employee Info have updated");
            }
            else
            {
                return BadRequest("Error in Process of Update");
            }

        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete_Employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee entity = await _repo.FirstOrDefault(x => x.ID == id);
               
            int flag = await _repo.DeleteEntity(entity);
            if (flag == 0)
                return BadRequest("error in the Delete proccess");


            return Ok("The Employee successfully Deleted");


        }
    }
}

