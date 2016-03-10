namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellPhoneRequest",
                c => new
                    {
                        SellPhoneRequestId = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                        Quantity = c.String(),
                        Model = c.String(),
                        Carrier = c.String(),
                        Capacity = c.String(),
                        Condition = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SellPhoneRequestId);
            
            AddColumn("dbo.PriceListRequest", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PriceListRequest", "BusinessName", c => c.String(nullable: false));
            AlterColumn("dbo.PriceListRequest", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PriceListRequest", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.PriceListRequest", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PriceListRequest", "Phone", c => c.String());
            AlterColumn("dbo.PriceListRequest", "Email", c => c.String());
            AlterColumn("dbo.PriceListRequest", "Name", c => c.String());
            AlterColumn("dbo.PriceListRequest", "BusinessName", c => c.String());
            DropColumn("dbo.PriceListRequest", "CreatedDate");
            DropTable("dbo.SellPhoneRequest");
        }
    }
}
