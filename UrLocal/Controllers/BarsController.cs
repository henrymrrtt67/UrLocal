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
    [Route("[controller]")]
    public class BarsController : Controller
    {
        private readonly ILogger<BarsController> _logger;

        public BarsController(ILogger<BarsController> logger)
        {
            _logger = logger;
        }


        // GET: api/values
        [HttpGet]
        public string Get([FromBody]int id)
        {
            /*UrLocalContext conn = new UrLocalContext();
            (List<int> bar_id, List<int> craft, List<int> complexities,
            List<bool[]> checkBox, List<double> lowerQuartileMeal, List<double> lowerQuartileBeer, List<double> upperQuartileMeal,
            List<double> upperQuartileBeer) = conn.get_bar();
            K_Nearest_Neighbour knn = new K_Nearest_Neighbour();
            knn.training(id);
            int bestBar = 0;
            for (int i = 0; i < bar_id.Count; i++) bestBar = knn.testing(bar_id[i], craft[i], complexities[i],
                 checkBox[i], lowerQuartileMeal[i], lowerQuartileBeer[i], upperQuartileMeal[i], upperQuartileBeer[i]);
            (string bar_name, string bar_location) = conn.bar_location(bestBar);
            return JsonConvert.SerializeObject(new Bars
            {
                barName = bar_name,
                barLocation = bar_location
            });*/
            return "";
        }


        // POST api/values
        [HttpPost]
        public void Post(string barname, int craft_slide,int complexity,
        int wineOrBeer, int wineCheck, int beerCheck, int spiritCheck,
        string filepath)
        {
            /*using (StreamReader sr = File.OpenText(filepath))
            {

            }*/
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
    }
}
