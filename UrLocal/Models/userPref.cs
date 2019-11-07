using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UrLocal.Models
{
    public class userPref
    {
        [Key]
        public int user_id { get; set; }

        public int craft_slide { get; set; }

        public int complexity { get; set; }

        public double price_range { get; set; }
    }
}
