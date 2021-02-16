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
        private readonly IRepositry _repo;
        private readonly DataContext _context;

        public EmployeeAuthController(IRepositry repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        //  GET: api/EmployeeAuth/
        [HttpGet("get")]
        public string Get()
        {
            return "value";
        }

        // POST: api/EmployeeAuth
        [HttpPost("register")]
        public async Task<IActionResult> Register(Employee Emp)
        {
            Emp.Username = Emp.Username.ToLower();
            if (await _repo.UserExists(Emp.Username))
            {
                return BadRequest("Employee is already Exists");
            }
            var EmpCreate = new Employee
            {
                Username = Emp.Username,
                Password = Emp.Password,
                MangerID = 1,
                Vacations = 16,
                Status = true   

            };
            var CreatedEmp = await _repo.Register(EmpCreate);

            return Ok(CreatedEmp);
        }
        [HttpPost("employeeLogin")]
        public async Task<IActionResult> LoginForEmployee(Employee Emp)
        {
            if(Emp==null)
                return BadRequest("Employee is null");

            var userFromRepo = await _repo.Login(Emp.Username.ToLower(), Emp.Password);


            if (userFromRepo == null)
            {
                return Unauthorized();
            }
            return Ok(userFromRepo);
        }
        [AllowAnonymous]
        [HttpGet("getEmployee")]
        public IEnumerable GetEmployee()
        {
            return _context.Employeess;
        }
    }
}

