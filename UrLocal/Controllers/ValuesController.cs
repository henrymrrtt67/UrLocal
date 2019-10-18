using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrLocal
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet("{username,password}", Name="getUser")]
        public int Get(string username, string password)
        {
            UrLocalDB conn = new UrLocalDB();
            return conn.userIdentification(username, password);
        }

        // GET api/values
        [HttpGet("{id}", Name="getBars")]
        public (string,string) Get(int id)
        {
            UrLocalDB conn = new UrLocalDB();
            (List<int> bar_id, List<int> craftBeers, List<int> complexities, List<int> wineOrBeers,
            List<bool[]> checkBox, List<double> lowerQuartileMeal, List<double> lowerQuartileBeer, List<double> upperQuartileMeal,
            List<double> upperQuartileBeer) = conn.get_bar();
            K_Nearest_Neighbour knn = new K_Nearest_Neighbour();
            knn.training(id);
            int bestBar = 0;
            for (int i = 0; i < bar_id.Count; i++) bestBar = knn.testing(bar_id[i],craftBeers[i],complexities[i],
                wineOrBeers[i], checkBox[i],lowerQuartileMeal[i],lowerQuartileBeer[i],upperQuartileMeal[i],upperQuartileBeer[i]);
            (string bar_name, string bar_location)=conn.bar_location(bestBar);
            return (bar_name,bar_location);
        }

        // POST api/values
        [HttpPost("{id}", Name="addBar")]
        public bool Post(string barname, int craft_slide, int complexity,
        int wineOrBeer, int wineCheck, int beerCheck, int spiritCheck, double lowerQuartileMeal,
        double lowerQuartileBeer, double upperQuartileMeal, double upperQuartileBeer, string location)
        {
            UrLocalDB conn = new UrLocalDB();
            return conn.add_bar(barname, craft_slide,complexity,wineOrBeer,wineCheck,beerCheck, spiritCheck,lowerQuartileMeal,
            lowerQuartileBeer, upperQuartileMeal, upperQuartileBeer, location);
        }

        [HttpPost("{id}",Name ="addUser")]
        public bool Post(string username, string password, int craft_slide, int complexity,
        int wineOrBeer, int wineCheck, int beerCheck, int spiritCheck, double priceRange)
        {
            UrLocalDB conn = new UrLocalDB();
            return conn.add_user(username,password,craft_slide, complexity, wineOrBeer, wineCheck, beerCheck, spiritCheck,priceRange);
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
