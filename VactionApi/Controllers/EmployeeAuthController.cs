using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
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
        

        public EmployeeAuthController(IRepositry<Employee> repo)
        {
            _repo = repo;
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
                return BadRequest("Employee is already Exists");
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
                return BadRequest("The login is incorrect your password or username wrong");
            }

            return Ok(employee);

        }
    
        [AllowAnonymous]
        [HttpGet("getEmployee")]
        public async Task< IEnumerable> GetEmployee()
        {
            return await _repo.GetAllEntity();
        }
    }
}

