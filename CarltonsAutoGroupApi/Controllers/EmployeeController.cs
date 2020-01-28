using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarltonsAutoGroupApi.Models;
using CarltonsAutoGroupApi.DBcontext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarltonsAutoGroupApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public EmployeeController(DatabaseContext db)
        {
            _db = db;
        }

        // Action Methods
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_db.Employees.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee objEmployee)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("There was an error while creating a new employee");
            }
            _db.Employees.Add(objEmployee);
            await _db.SaveChangesAsync();

            return new JsonResult("The employee was created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee objEmployee)
        {
            if (objEmployee == null || id != objEmployee.EmployeeId)
            {
                return new JsonResult("The employee was not found");
            }
            else
            {
                _db.Employees.Update(objEmployee);
                await _db.SaveChangesAsync();
                return new JsonResult("The employee was updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var findEmployee = await _db.Employees.FindAsync(id);
            if (findEmployee == null)
            {
                return NotFound();
            }
            else
            {
                _db.Employees.Remove(findEmployee);
                await _db.SaveChangesAsync();
                return new JsonResult("The employee was deleted successfully");
            }
        }
    }
}
