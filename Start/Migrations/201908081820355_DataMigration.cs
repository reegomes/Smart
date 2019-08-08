namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cotacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.String(),
                        Genero = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        AnoFabricacao = c.String(),
                        AnoModelo = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cotacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Cotacaos", new[] { "Cliente_Id" });
            DropTable("dbo.Cotacaos");
            DropTable("dbo.Clientes");
        }
    }
}
