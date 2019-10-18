using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrLocal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            /* UrLocalDB conn = new UrLocalDB();
             int id = conn.userIdentification(username, password);
             (int craft, int complexity, bool[] checkbox, double priceRange) = conn.get_user_preferences(id);
             */
            return "hello world";
        }

        // POST api/values
        /*[HttpPost]
        public Users Post(string [] data)
        {
            /*UrLocalDB conn = new UrLocalDB();
            conn.add_user(username, password, craft_slide, complexity, wineCheck, beerCheck, spiritCheck, priceRange);

            return new Users {
                userName = username,
                Password = password,
                craftSlide = craft_slide,
                Complexity = complexity,
                WineCheck = wineCheck,
                BeerCheck = beerCheck,
                SpiritCheck = spiritCheck,
                PriceRange = priceRange
            };
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }*/
    }
}
