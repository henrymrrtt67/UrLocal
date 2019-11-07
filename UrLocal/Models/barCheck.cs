using System;
using System.ComponentModel.DataAnnotations;

namespace UrLocal.Models
{
    public class barCheck
    {
        [Key]
        public int bar_id { get; set; }

        public bool wine { get; set; }

        public bool beer { get; set; }

        public bool spirit { get; set; }
    }
}
