namespace ZarzadzanieProduktami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        KategoriaId = c.Int(nullable: false),
                        Cena = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produkt", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.Produkt", new[] { "KategoriaId" });
            DropTable("dbo.Produkt");
            DropTable("dbo.Kategoria");
        }
    }
}
