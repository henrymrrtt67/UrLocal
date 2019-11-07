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
        public string bar_name{ get; set; }

        public int street_num { get; set; }

        public string street_name { get; set; }

        public string suburb { get; set; }

        public string city { get; set; }

        public static implicit operator int(Bars v)
        {
            throw new NotImplementedException();
        }
    }
}
