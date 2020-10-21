namespace Client_Serveur_Travail_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprunts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client_Id = c.Int(),
                        Musique_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Musiques", t => t.Musique_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Musique_Id);
            
            CreateTable(
                "dbo.Musiques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Duree = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Auteur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auteurs", t => t.Auteur_Id)
                .Index(t => t.Auteur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprunts", "Musique_Id", "dbo.Musiques");
            DropForeignKey("dbo.Musiques", "Auteur_Id", "dbo.Auteurs");
            DropForeignKey("dbo.Emprunts", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Musiques", new[] { "Auteur_Id" });
            DropIndex("dbo.Emprunts", new[] { "Musique_Id" });
            DropIndex("dbo.Emprunts", new[] { "Client_Id" });
            DropTable("dbo.Musiques");
            DropTable("dbo.Emprunts");
            DropTable("dbo.Clients");
            DropTable("dbo.Auteurs");
        }
    }
}
