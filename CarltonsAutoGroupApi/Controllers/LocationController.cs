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
    public class LocationController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public LocationController(DatabaseContext db)
        {
            _db = db;
        }

        // Action Methods
        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_db.Locations.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] Location objLocation)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("There was an error while creating a new location");
            }
            _db.Locations.Add(objLocation);
            await _db.SaveChangesAsync();

            return new JsonResult("The location was created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation([FromRoute] int id, [FromBody] Location objLocation)
        {
            if (objLocation == null || id != objLocation.LocationId)
            {
                return new JsonResult("The location was not found");
            }
            else
            {
                _db.Locations.Update(objLocation);
                await _db.SaveChangesAsync();
                return new JsonResult("The location was updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            var findLocation = await _db.Locations.FindAsync(id);
            if (findLocation == null)
            {
                return NotFound();
            }
            else
            {
                _db.Locations.Remove(findLocation);
                await _db.SaveChangesAsync();
                return new JsonResult("The location was deleted successfully");
            }
        }
    }
}
