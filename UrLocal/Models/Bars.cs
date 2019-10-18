using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace UrLocal
{
    // Bars model
    public class Bars
    {
        // Primary Key barId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int barId { get; set; }
      
        // Other Attributes in my Bars table.
        public string barName{ get; set; }

        public string barLocation { get; set; }

        public int craftSlide { get; set; }

        public int complexity { get; set; }

        public bool wineCheck { get; set; }

        public bool beerCheck { get; set; }

        public bool spiritCheck { get; set; }

        public double lqMeal { get; set; }

        public double lqBeer { get; set; }

        public double uqMeal { get; set; }

        public double uqBeer { get; set; }

    }
}
