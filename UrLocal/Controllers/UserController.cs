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
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Checks if the model for the login is completely valid returning it is incorrect if not
            return Ok(_db.users.ToList());
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] Login log)
        {
            // Checks if the model for the login is completely valid returning it is incorrect if not
            if (!ModelState.IsValid)
            {
                return new JsonResult("Incorrectly input login");
            }
            // Queries the database for the particular username and password combination from the database
            var user = from u in _db.users
                       where (u.userName.Equals(log.username) && u.Password.Equals(log.password))
                       select u;
            if (user != null) return new JsonResult("Username and Password Found!");
            return new JsonResult("Username or Password incorrect");
        }

        // creating new Users within the users database in where the object is passed through and then entered into the database.
        // the object is exactly mirrored like the model that is previously put through.
        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] Users objUsers)
        {
            // Checks if the model structure is fully valid otherwise it will return that it is not valid.
            if (!ModelState.IsValid)
            { 
                return new JsonResult("Error While Creating New User");
            }
            // Adds the user inputted into the database
            _db.users.Add(objUsers);
            // Waits and makes sure the database saves the changes
            await _db.SaveChangesAsync();
            // Returns to the front end that the user has been inserted into the bar.
            return new JsonResult("User inserted successfully");
        }

        // Updating User details, more importantly when they change their bar preference
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] Users objUser)
        {
            if (objUser == null || id != objUser.userId)
            {
                return new JsonResult("This User cannot be updated");
            }
            else
            {
                _db.users.Update(objUser);
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
            if (findUser == null) return NotFound();
            else
            {
                _db.users.Remove(findUser);
                await _db.SaveChangesAsync();

                return new JsonResult("User Was Removed Successfully");
            }
        }
    }
}
