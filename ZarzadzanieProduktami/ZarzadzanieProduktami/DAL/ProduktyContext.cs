using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ZarzadzanieProduktami.Models;

namespace ZarzadzanieProduktami.DAL
{
    public class ProduktyContext:DbContext
    {
        public ProduktyContext() : base("BazaProdukty") { }

        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Produkt> Produkty { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}