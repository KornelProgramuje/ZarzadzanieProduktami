namespace ZarzadzanieProduktami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Walidacjadanych : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kategoria", "NazwaKategorii", c => c.String(nullable: false));
            AlterColumn("dbo.Produkt", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Produkt", "Opis", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produkt", "Opis", c => c.String());
            AlterColumn("dbo.Produkt", "Nazwa", c => c.String());
            AlterColumn("dbo.Kategoria", "NazwaKategorii", c => c.String());
        }
    }
}
