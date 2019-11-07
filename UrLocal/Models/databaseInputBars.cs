using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UrLocal.Models
{
    public class databaseInputBars
    {
        // Primary Key barId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bar_id { get; set; }

       
        // Other Attributes in my Bars table.
        public string barName { get; set; }

        public int street_num { get; set; }

        public string street_name { get; set; }

        public string suburb { get; set; }

        public string city { get; set; }

        public int craftSlide { get; set; }

        public int complexity { get; set; }

        public bool wineCheck { get; set; }

        public bool beerCheck { get; set; }

        public bool spiritCheck { get; set; }

        public int lqMeal { get; set; }

        public int lqBeer { get; set; }

        public int uqMeal { get; set; }

        public int uqBeer { get; set; }

    }
}
