using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrLocal.Models
{
    public class userCheck
    {
        [Key]
        public int user_id { get; set; }

        public bool wine { get; set; }

        public bool beer { get; set; }

        public bool spirit { get; set; }
    }
}
