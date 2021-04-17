using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LucrareDeDisertatie.Models
{
    public class Utilizator
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int idUtilizator { get; set; }
        [Required(ErrorMessage = "Camp obligatoriu.")]
        [StringLength(50, MinimumLength = 2)]
        public string Nume { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Prenume { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Parola { get; set; }

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Parola")]
        public string VerificareParola { get; set; }
        public string NumeComeplt()
        {
            return this.Nume + " " + this.Prenume;
        }
    }
}