using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebImmobilier.Models
{
    public class bdImmobilierContext: DbContext
    {

        public bdImmobilierContext() : base("connImmobilier")
        {

        }
        public DbSet<Bien> biens { get; set; }
        public DbSet<Maison> maisons { get; set; }
        public DbSet<Proprietaire> proprietaires { get; set; }
        public DbSet<Appartement> appartements { get; set; }
        public DbSet<Studio> studios { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }

        
    }
}