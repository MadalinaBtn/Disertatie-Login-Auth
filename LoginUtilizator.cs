﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LucrareDeDisertatie.Models
{
    public class LoginUtilizator
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Parola { get; set; }

    }
}