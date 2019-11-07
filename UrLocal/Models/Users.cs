﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrLocal
{
    public class Users
    {
        // Primary Key userId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        // Other attributes used within this
        public string userName { get; set; }

        public string Password { get; set; }


    }
}
