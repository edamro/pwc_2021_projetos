namespace P3_MVC_EF6_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Receita",
                c => new
                    {
                        ReceitaID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        GrauDificuldadeID = c.Int(nullable: false),
                        ReceitaNome = c.String(nullable: false, maxLength: 30),
                        ReceitaDescricao = c.String(nullable: false, maxLength: 200),
                        ReceitaDuracao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceitaID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.GrauDificuldade", t => t.GrauDificuldadeID, cascadeDelete: true)
                .Index(t => t.CategoriaID)
                .Index(t => t.GrauDificuldadeID);
            
            CreateTable(
                "dbo.GrauDificuldade",
                c => new
                    {
                        GrauDificuldadeID = c.Int(nullable: false, identity: true),
                        GrauDificuldadeNome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.GrauDificuldadeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receita", "GrauDificuldadeID", "dbo.GrauDificuldade");
            DropForeignKey("dbo.Receita", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Receita", new[] { "GrauDificuldadeID" });
            DropIndex("dbo.Receita", new[] { "CategoriaID" });
            DropTable("dbo.GrauDificuldade");
            DropTable("dbo.Receita");
            DropTable("dbo.Categoria");
        }
    }
}
