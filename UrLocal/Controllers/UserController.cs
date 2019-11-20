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
    public class UsersController : ControllerBase
    {
        // makes it so that this instance of _db cannot be changed but the table itself can
        private readonly UrLocalContext _db;

        // Passes through the current context database and makes it equal to the local database
        public UsersController(UrLocalContext db)
        {
            _db = db;
        }

        // Action Methods
        // GET: api/values
        // gets a 200
        // Once Get is called for this controller then it is getting all relevant Bars

        // Http get will probably be more useful for getting the users login details and the users preferences will be passed through.
        [HttpGet("{id}")]
        public IActionResult getPrefBar([FromRoute] int id)
        {
            if(_db.users.Find(id) != null)
            {
                K_Nearest_Neighbour knn = new K_Nearest_Neighbour();
                Users u = _db.users.Find(id);
                userPref up = _db.user_pref.Find(id);
                userCheck uc = _db.user_check.Find(id);
                databaseInputUser user = new databaseInputUser();
                user.craftSlide = up.craft_slide;
                user.Complexity = up.complexity;
                user.PriceRange = up.price_range;
                user.WineCheck = uc.wine;
                user.BeerCheck = uc.beer;
                user.SpiritCheck = uc.spirit;
                int bbid = 0;
                foreach (Bars b in _db.bars.ToArray())
                {
                    int currentID = b.barId;
                    barScore bs =  _db.bar_score.Find(currentID);
                    barCheck bc = _db.bar_check.Find(currentID);
                    databaseInputBars db = new databaseInputBars();
                    db.bar_id = b.barId;
                    db.craftSlide = bs.craft_slide;
                    db.complexity = bs.complexity;
                    db.lqBeer = (int)bs.lqBeer;
                    db.lqMeal = (int)bs.lqMeal;
                    db.uqBeer = (int)bs.uqBeer;
                    db.uqMeal = (int)bs.uqMeal;
                    db.beerCheck = bc.beer;
                    db.wineCheck = bc.wine;
                    db.spiritCheck = bc.spirit;
                    bbid = knn.testing(user, db);
                }
                return Ok(_db.bars.Find(bbid));
            }
            return NotFound();
        }
        [HttpGet("userPref/{id}")]
        public IActionResult getUserPref([FromRoute] int id)
        {
            if (_db.users.Find(id) != null)
            {
                Users u = _db.users.Find(id);
                userPref up = _db.user_pref.Find(id);
                userCheck uc = _db.user_check.Find(id);
                databaseInputUser user = new databaseInputUser();
                user.craftSlide = up.craft_slide;
                user.Complexity = up.complexity;
                user.PriceRange = up.price_range;
                user.WineCheck = uc.wine;
                user.BeerCheck = uc.beer;
                user.SpiritCheck = uc.spirit;
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            // Checks if the model for the login is completely valid returning it is incorrect if not

            return Ok(_db.user_check.ToList());
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] Login log)
        {
            // Checks if the model for the login is completely valid returning it is incorrect if 
            Console.WriteLine(log.username);
            Console.WriteLine(log.password);
            if (!ModelState.IsValid)
            {
                return new JsonResult("Incorrectly input login");
            }
            // Queries the database for the particular username and password combination from the database
            var user = from u in _db.users
                       where (u.userName.Equals(log.username) && u.Password.Equals(log.password))
                       orderby u.userId
                       select u;
            foreach (var u in user)
            {
                if (u.Password.Equals(log.password)&&u.userName.Equals(log.username)) {
                    Console.WriteLine(u.userId);
                    if (u != null) return new JsonResult(u.userId);
                }
                else
                {
                    return new JsonResult(-1);
                }
            }
            return new JsonResult("Username or Password incorrect");
        }

        // creating new Users within the users database in where the object is passed through and then entered into the database.
        // the object is exactly mirrored like the model that is previously put through.
        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] databaseInputUser objUsers)
        {
            // Checks if the model structure is fully valid otherwise it will return that it is not valid.
            if (!ModelState.IsValid)
            { 
                return new JsonResult("Error While Creating New User");
            }
            // Adds the user inputted into the database
            Users u = new Users();
            u.userName = objUsers.userName;
            u.Password = objUsers.Password;
            _db.users.Add(u);
            await _db.SaveChangesAsync();

            Users user = _db.users.Find(u.userId);
            int id = user.userId;
            userPref up = new userPref();
            up.user_id = id;
            up.craft_slide = objUsers.craftSlide;
            up.complexity = objUsers.Complexity;
            up.price_range = objUsers.PriceRange;
            _db.user_pref.Add(up);
            await _db.SaveChangesAsync();
            userCheck uc = new userCheck();
            uc.user_id = id;
            uc.wine = objUsers.WineCheck;
            uc.beer = objUsers.BeerCheck;
            uc.spirit = objUsers.SpiritCheck;
            _db.user_check.Add(uc);
            // Waits and makes sure the database saves the changes
            await _db.SaveChangesAsync();
            // Returns to the front end that the user has been inserted into the bar.
            return new JsonResult("User inserted successfully");
        }

        // Updating User details, more importantly when they change their bar preference
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] databaseInputUser objUser)
        {
            if (objUser == null || id != objUser.userId)
            {
                return new JsonResult("This User cannot be updated");
            }
            else
            {
                userPref up = new userPref();
                up.user_id = id;
                up.craft_slide = objUser.craftSlide;
                up.complexity = objUser.Complexity;
                up.price_range = objUser.PriceRange;
                _db.user_pref.Update(up);
                userCheck uc = new userCheck();
                uc.user_id = objUser.userId;
                uc.wine = objUser.WineCheck;
                uc.beer = objUser.BeerCheck;
                uc.spirit = objUser.SpiritCheck;
                _db.user_check.Update(uc);
                await _db.SaveChangesAsync();

                return new JsonResult("User has been updated");
            }
        }

        // DELETE api/values/5

        //deleting the user from the user database.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            var findUser = await _db.users.FindAsync(id);
            var findUserCheck = await _db.user_check.FindAsync(id);
            var findUserPref = await _db.user_pref.FindAsync(id);
            if (findUser == null) return NotFound();
            else
            {
                _db.users.Remove(findUser);
                _db.user_check.Remove(findUserCheck);
                _db.user_pref.Remove(findUserPref);
                await _db.SaveChangesAsync();

                return new JsonResult("User Was Removed Successfully");
            }
        }
    }
}
