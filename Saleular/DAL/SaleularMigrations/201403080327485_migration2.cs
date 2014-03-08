namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gadget", "GadgetId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Gadget");
            AddPrimaryKey("dbo.Gadget", "GadgetId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Gadget");
            AddPrimaryKey("dbo.Gadget", "GadgetID");
            AlterColumn("dbo.Gadget", "GadgetId", c => c.Int(nullable: false, identity: true));
        }
    }
}
