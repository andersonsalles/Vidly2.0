namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        IdGenre = c.Byte(),
                        Teste = c.Int(nullable: false),
                        
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.IdGenre)
                .Index(t => t.IdGenre);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "IdGenre", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "IdGenre" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
