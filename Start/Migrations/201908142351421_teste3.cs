namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coberturas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        Produto_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_id)
                .Index(t => t.Produto_id);
            
            CreateTable(
                "dbo.CotacaoCompletas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RCF = c.Double(nullable: false),
                        APP = c.Double(nullable: false),
                        PeqReparos = c.Boolean(nullable: false),
                        AssAuto = c.Boolean(nullable: false),
                        CorbCompleta = c.Boolean(nullable: false),
                        produto_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Produtoes", t => t.produto_id)
                .Index(t => t.produto_id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        ValorParcela = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CotacaoCompletas", "produto_id", "dbo.Produtoes");
            DropForeignKey("dbo.Coberturas", "Produto_id", "dbo.Produtoes");
            DropIndex("dbo.CotacaoCompletas", new[] { "produto_id" });
            DropIndex("dbo.Coberturas", new[] { "Produto_id" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.CotacaoCompletas");
            DropTable("dbo.Coberturas");
        }
    }
}
