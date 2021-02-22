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
        public async Task<IActionResult> Register(Employee emp)
        {
            emp.Username = emp.Username.ToLower();
            if (await _repo.EntityExists(emp))
            {
                return BadRequest("Employee is already Exists");
            }
            var empCreate = new Employee
            {
                Username = emp.Username,
                Password = emp.Password,
                MangerID = 1,
                Vacations = 16,
                Status = true

            };
            var createdEmp = await _repo.AddEntity(empCreate);

            return Ok(createdEmp);
        }
        [HttpPost("employeeLogin")]
        public async Task<IActionResult> LoginForEmployee(Employee emp)
        {
            if (emp == null)
                return BadRequest("Employee is null");

            var employee = await _repo.FindEntity(emp);
            if (employee == null)
            {
                return Unauthorized();
            }
            if (await _repo.CheckEntity(employee, employee.ID))
                return Ok(employee);
            return BadRequest("The Password is incorrect");

            


        }
    
        [AllowAnonymous]
        [HttpGet("getEmployee")]
        public async Task< IEnumerable> GetEmployee()
        {
            return await _repo.GetAllEntity();
        }
    }
}

