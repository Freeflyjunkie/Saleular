namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gadget", "Type", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Gadget", "Model", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Gadget", "Capacity", c => c.String(nullable: false));
            AlterColumn("dbo.Gadget", "Carrier", c => c.String(nullable: false));
            AlterColumn("dbo.Gadget", "Condition", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Gadget", "ImageUrl", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gadget", "ImageUrl", c => c.String(maxLength: 500));
            AlterColumn("dbo.Gadget", "Condition", c => c.String(maxLength: 10));
            AlterColumn("dbo.Gadget", "Carrier", c => c.String());
            AlterColumn("dbo.Gadget", "Capacity", c => c.String());
            AlterColumn("dbo.Gadget", "Model", c => c.String(maxLength: 10));
            AlterColumn("dbo.Gadget", "Type", c => c.String(maxLength: 25));
        }
    }
}
