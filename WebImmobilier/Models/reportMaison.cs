using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebImmobilier.Models
{
    public class reportMaison
    {

        public int IdBien { get; set; }
        public string DescriptionBien { get; set; }
        public float SuperficieBien { get; set; }
        public string Localite { get; set; }
        public int NbreSalleEau { get; set; }
        public int NbreCuisine { get; set; }
        public int NbreToilette { get; set; }

        public int? IdProprio { get; set; }
        public string Proprietaire  { get; set; }
        public int NbreChambre { get; set; }
    }
}