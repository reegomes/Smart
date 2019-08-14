namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residencials", "AptoCasa", c => c.Boolean(nullable: false));
            AddColumn("dbo.Residencials", "IQRE", c => c.Boolean(nullable: false));
            AddColumn("dbo.Residencials", "FERB", c => c.Boolean(nullable: false));
            AddColumn("dbo.Residencials", "DT", c => c.Boolean(nullable: false));
            AddColumn("dbo.Residencials", "PPA", c => c.Boolean(nullable: false));
            DropColumn("dbo.Residencials", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Residencials", "Tipo", c => c.String());
            DropColumn("dbo.Residencials", "PPA");
            DropColumn("dbo.Residencials", "DT");
            DropColumn("dbo.Residencials", "FERB");
            DropColumn("dbo.Residencials", "IQRE");
            DropColumn("dbo.Residencials", "AptoCasa");
        }
    }
}
