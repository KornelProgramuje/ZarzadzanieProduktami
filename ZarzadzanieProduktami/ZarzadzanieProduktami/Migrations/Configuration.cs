namespace ZarzadzanieProduktami.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZarzadzanieProduktami.DAL.ProduktyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZarzadzanieProduktami.DAL.ProduktyContext";
        }

        protected override void Seed(ZarzadzanieProduktami.DAL.ProduktyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
