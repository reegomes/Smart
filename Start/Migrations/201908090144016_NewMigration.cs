namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Cotacao_Id", "dbo.Cotacaos");
            DropIndex("dbo.Clientes", new[] { "Cotacao_Id" });
            AddColumn("dbo.Cotacaos", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Cotacaos", "Cliente_Id");
            AddForeignKey("dbo.Cotacaos", "Cliente_Id", "dbo.Clientes", "Id");
            DropColumn("dbo.Clientes", "Cotacao_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Cotacao_Id", c => c.Int());
            DropForeignKey("dbo.Cotacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Cotacaos", new[] { "Cliente_Id" });
            DropColumn("dbo.Cotacaos", "Cliente_Id");
            CreateIndex("dbo.Clientes", "Cotacao_Id");
            AddForeignKey("dbo.Clientes", "Cotacao_Id", "dbo.Cotacaos", "Id");
        }
    }
}
