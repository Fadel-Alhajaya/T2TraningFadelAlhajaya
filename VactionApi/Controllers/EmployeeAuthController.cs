using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using vacation_System.Models;

using VactionApi.Data;

namespace VactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : ControllerBase
    {
        private readonly IRepositry _repo;

        public EmployeeAuthController(IRepositry repo)
        {
            _repo = repo;
        }
        // GET: api/EmployeeAuth
        //[HttpGet]
        //public string IActionResult  Get()
        //{
        //    return "value";
        //}

        //  GET: api/EmployeeAuth/
        [HttpGet]
        public string Get()
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

       
    }
}
