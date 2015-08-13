namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellPhoneRequest",
                c => new
                    {
                        PriceListRequestId = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                        TaxId = c.String(),
                        BusinessAreaSelection = c.String(),
                        Quantity = c.String(),
                        Model = c.String(),
                        Carrier = c.String(),
                        Capacity = c.String(),
                        Condition = c.String(),
                    })
                .PrimaryKey(t => t.PriceListRequestId);
            
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
            DropTable("dbo.SellPhoneRequest");
        }
    }
}
