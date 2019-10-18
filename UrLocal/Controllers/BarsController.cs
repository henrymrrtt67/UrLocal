using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.UrLocal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrLocal.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BarsController : ControllerBase
    {
        // makes it so that this instance of _db cannot be changed but the table itself can
        private readonly UrLocalContext _db;

        // Passes through the current context database and makes it equal to the local database
        public BarsController(UrLocalContext db)
        {
            _db = db;
        }

        // Action Methods
        // GET: api/values
        // gets a 200
        // Once Get is called for this controller then it is getting all relevant Bars

        /* Edit this so that it passes through a login model through this so that it will only purely return OK and the 
         * list of the local bars, in which I will be able to get the location from this JSON.
         */
        [HttpGet]
        public IActionResult GetBars()
        {
            return Ok(_db.bars.ToList());
            
        }


        // POST api/values
        /* Just the general creation of bars within the table and passes through the object so that it can be placed into the right
         * database and added through this.
         * Make sure this works with the data entry Front end as this is all it will probably ever be used for.
         */
        [HttpPost]
        public async Task<IActionResult> AddBar([FromBody] Bars objBars)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Bar");
            }
            _db.bars.Add(objBars);
            await _db.SaveChangesAsync();

            return new JsonResult("Bar inserted successfully");
        }

        // updating values within the database, will be useful as users change what their preferences for bars will be.
        // May be irrelevant for the moment.
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBar([FromRoute] int id, [FromBody] Bars objBars)
        {
            if (objBars ==null || id != objBars.barId)
            {
                return new JsonResult("This Bar cannot be updated");
            }
            else
            {
                _db.bars.Update(objBars);
                await _db.SaveChangesAsync();

                return new JsonResult("Bar has been updated");
            }
        }

        // DELETE api/values/5
        // Deleting a bar from the table.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBar([FromRoute]int id)
        {
            var findBar = await _db.bars.FindAsync(id);
            if (findBar == null) return NotFound();
            else
            {
                _db.bars.Remove(findBar);
                await _db.SaveChangesAsync();

                return new JsonResult("Bar Was Removed Successfully");
            }
        }
    }
}
