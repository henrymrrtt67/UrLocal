using System;
using System.ComponentModel.DataAnnotations;

namespace UrLocal.Models
{
    public class barScore
    {
        [Key]
        public int bar_id { get; set; }

        public int craft_slide { get; set; }

        public int complexity { get; set; }

        public double lqMeal { get; set; }

        public double lqBeer { get; set; }

        public double uqMeal { get; set; }

        public double uqBeer { get; set; }
    }
}
