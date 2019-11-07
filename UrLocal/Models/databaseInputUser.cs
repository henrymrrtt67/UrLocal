using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrLocal
{
    public class databaseInputUser
    {
        // Primary Key userId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        // Other attributes used within this
        public string userName { get; set; }

        public string Password { get; set; }

        public int craftSlide { get; set; }

        public int Complexity { get; set; }

        public bool WineCheck { get; set; }

        public bool BeerCheck { get; set; }

        public bool SpiritCheck { get; set; }

        public double PriceRange { get; set; }
    }
}
