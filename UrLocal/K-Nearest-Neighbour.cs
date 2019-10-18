using System;
using Data.UrLocal;

namespace UrLocal
{
    public class K_Nearest_Neighbour
    {
        int craft = 0;
        int complexity = 0;
        bool[] checkboxes = null;
        double priceRange = 100.0;

        int best_bar_id = 0;
        double best_bar_score = 100.0;

        public K_Nearest_Neighbour()
        {

        }
        public void training(int user_id)
        {
        /*    UrLocalContext conn = new UrLocalContext();
            (craft, complexity, checkboxes, priceRange)=conn.get_user_preferences(user_id);*/
        }
        public int testing(int bar_id, int barCraft, int complexities,
            bool[] checkbox, double lqMealPrice, double lqBeerPrice, double uqMealPrice, double uqBeerPrice)
        {
        /*    int craftScore = craft - barCraft;
            if (craftScore<0) craftScore *= -1;
            int compScore = complexity - complexities;
            if (compScore<0) compScore *= -1;
            int checkboxScore = 0;
            for (int i =0; i<checkbox.Length;i++)
            {
                if (checkboxes[i].Equals(checkbox[i])) checkboxScore += 5;
            }
            double price = priceRange + lqMealPrice;
            if (price < 0) price *= -1;
            if (price<priceRange) priceRange=price;
            price = priceRange + lqBeerPrice;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            price = priceRange + uqMealPrice;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            price = priceRange + uqBeerPrice;
            if (price < 0) price *= -1;
            if (price < priceRange) priceRange = price;
            double totalScore = craftScore + compScore + checkboxScore + priceRange;
            if (best_bar_score > totalScore)
            {
                best_bar_id = bar_id;
                best_bar_score = totalScore;
            } */
            return -1;
        }
    }
}
