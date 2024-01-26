using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "*"), MaxLength(100), Display(Name = "Nom d'utilisateur")]
        public string NomUser { get; set; }

        [Required(ErrorMessage = "*"), MaxLength(100), Display(Name = "Votre Prenom ")]
        public string PrenomUser { get; set; }

        [Required(ErrorMessage = "*"), MaxLength(100), Display(Name = " votre email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "*"), MaxLength(50), Display(Name = "Votre mot de pass")]
        public string Password { get; set; }
    }
}