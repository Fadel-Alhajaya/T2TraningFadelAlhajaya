using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacation_System.Models;
using VactionApi.Data;

namespace VactionApi.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 [EnableCors("CorePolicy")]
    public class MangeVactionEmployeeController : ControllerBase
    { 
    
        private readonly IRepositry<Vacation> _repo;
        private readonly IRepositry<Employee> _erepo;


        public MangeVactionEmployeeController(IRepositry<Vacation> repo, IRepositry<Employee> erepo)
        {
            _repo = repo;
            _erepo = erepo;

        }
        // Post: api/<MangeVactionEmployeeController>/
        [HttpPost]
        [Route("Vaction_Mange/{VactionID}")]
        public async Task<IActionResult> AcceptEmployeeVactionAsync(int VactionID)
        {
            Vacation request = await _repo.Find(x=> x.Id==VactionID);
            Employee employeeVaction =  await _erepo.Find( x=> x.ID ==request.EmpID);
            if (employeeVaction.Status == false && employeeVaction.Vacations > 16 && employeeVaction.Vacations == 0)
            {
                return BadRequest("You can't take A Vaction, Vaction Rejected");

            }
            employeeVaction.Vacations--;
            return Ok("Vaction Is Accepted");


        }


    }
}
