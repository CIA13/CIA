namespace CIA.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityPersonnes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(),
                        Age = c.Int(nullable: false),
                        Employeur_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EntitySocietes", t => t.Employeur_ID)
                .Index(t => t.Employeur_ID);
            
            CreateTable(
                "dbo.EntitySocietes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RaisonSociale = c.String(),
                        SIREN = c.Int(nullable: false),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityPersonnes", "Employeur_ID", "dbo.EntitySocietes");
            DropIndex("dbo.EntityPersonnes", new[] { "Employeur_ID" });
            DropTable("dbo.EntitySocietes");
            DropTable("dbo.EntityPersonnes");
        }
    }
}
