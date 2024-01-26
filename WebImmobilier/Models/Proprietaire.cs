using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Proprietaire:Utilisateur
    {

        public virtual ICollection<Bien> Propries { get; set; }


    }
}