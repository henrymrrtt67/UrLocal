using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.UrLocal;
using UrLocal.Models;

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
        public IActionResult getBars()
        {
            return Ok(_db.bars.ToList());
        }


        // POST api/values
        /* Just the general creation of bars within the table and passes through the object so that it can be placed into the right
         * database and added through this.
         * Make sure this works with the data entry Front end as this is all it will probably ever be used for.
         */
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> AddBar([FromBody] databaseInputBars objBars)
        {
            // Checks if the model is valid from the body and returns that this is incorrect
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Bar");
            }
            Bars b = new Bars();
            b.bar_name = objBars.barName;
            b.street_num = objBars.street_num;
            b.street_name = objBars.street_name;
            b.suburb = objBars.suburb;
            b.city = objBars.city;
            // Adds the bar to the database if this is correct.
            _db.bars.Add(b);
            await _db.SaveChangesAsync();
            Bars bar = _db.bars.Find(b.barId);
            int id = b.barId;
            barScore bs = new barScore();
            bs.bar_id = id;
            bs.craft_slide = objBars.craftSlide;
            bs.complexity = objBars.complexity;
            bs.lqBeer = objBars.lqBeer;
            bs.lqMeal = objBars.lqMeal;
            bs.uqBeer = objBars.uqBeer;
            bs.uqMeal = objBars.uqMeal;
            _db.bar_score.Add(bs);
            await _db.SaveChangesAsync();
            barCheck bc = new barCheck();
            bc.bar_id = id;
            bc.wine = objBars.wineCheck;
            bc.beer = objBars.beerCheck;
            bc.spirit = objBars.spiritCheck;
            _db.bar_check.Add(bc);
            // Waits and checks that the changes are saved within the database.
            await _db.SaveChangesAsync();
            // Returns that the Bar has been inserted into the database.
            return new JsonResult("Bar inserted successfully");
        }

        // updating values within the database, will be useful as users change what their preferences for bars will be.
        // May be irrelevant for the moment.
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBar([FromRoute] int id, [FromBody] databaseInputBars objBars)
        {
            if (objBars == null || _db.bars.Find(id) != null)
            {
                return new JsonResult("This Bar cannot be updated");
            }
            else
            {
                Bars b = new Bars();
                b.barId = id;
                barScore bs = new barScore();
                barCheck bc = new barCheck();
                b.bar_name = objBars.barName;
                b.street_num = objBars.street_num;
                b.street_name = objBars.street_name;
                b.suburb = objBars.suburb;
                b.city = objBars.city;
                bs.bar_id = id;
                bs.craft_slide = objBars.craftSlide;
                bs.complexity = objBars.complexity;
                bs.lqBeer = objBars.lqBeer;
                bs.lqMeal = objBars.lqMeal;
                bs.uqBeer = objBars.uqBeer;
                bs.uqMeal = objBars.uqMeal;
                bc.bar_id = id;
                bc.beer = objBars.beerCheck;
                bc.wine = objBars.wineCheck;
                bc.spirit = objBars.spiritCheck;
                _db.bars.Update(b);
                _db.bar_score.Update(bs);
                _db.bar_check.Update(bc);
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
            var findBarScore = await _db.bar_score.FindAsync(id);
            var findBarCheck = await _db.bar_check.FindAsync(id);
            if (findBar == null) return NotFound();
            else
            {
                _db.bars.Remove(findBar);
                _db.bar_score.Remove(findBarScore);
                _db.bar_check.Remove(findBarCheck);
                await _db.SaveChangesAsync();

                return new JsonResult("Bar Was Removed Successfully");
            }
        }
    }
}
