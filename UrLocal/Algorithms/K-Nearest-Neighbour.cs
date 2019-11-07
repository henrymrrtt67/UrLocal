using System;
using Data.UrLocal;
using UrLocal.Models;

namespace UrLocal
{
    public class K_Nearest_Neighbour
    {
        
        // Creates the global variables that will be needed throughout this instance.
        int best_bar_id  = 0;
        double best_bar_score = 100.0;


        // Constructor created but nothing placed in as an instance can just be created.
        public K_Nearest_Neighbour()
        {

        }

        // Passes both the users preferences and the bar
        // a comparison between the two is then made, and then
        public int testing(userPref u, barScore b, barCheck bc, userCheck uc)
        {
            double priceRange = 100.0;
            int craftScore = u.craft_slide - b.craft_slide;
            if (craftScore<0) craftScore *= -1;
            int compScore = u.complexity - b.complexity;
            if (compScore<0) compScore *= -1;
            int wineCheck = 0;
            if (!uc.wine.Equals(bc.wine)) wineCheck += 5;
            int beerCheck = 0;
            if (!uc.beer.Equals(bc.beer)) beerCheck += 5;
            int spiritCheck = 0;
            if (!uc.spirit.Equals(bc.spirit)) spiritCheck += 5;
            double price = u.price_range - b.lqMeal;
            if (price < 0) price *= -1;
            if (price<priceRange) priceRange=price;
            price = u.price_range + b.lqBeer;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            price = u.price_range + b.uqMeal;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            price = u.price_range + b.uqBeer;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            double totalScore = craftScore + compScore + wineCheck + beerCheck + spiritCheck + priceRange;
            // sets the current best bar based on the score, the smaller the value then the closer to the preferences of the user.
            if (best_bar_score > totalScore)
            {
                best_bar_id = b.bar_id;
                best_bar_score = totalScore;
            }
            // returns the id of the best bar each time so the final result is that of the best bar for the user preferences.
            return best_bar_id;
        }
    }
}
