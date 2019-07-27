namespace ManagerDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarrosMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Ano = c.String(),
                        Obs1 = c.String(),
                        Obs2 = c.String(),
                        Obs3 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carros");
        }
    }
}
