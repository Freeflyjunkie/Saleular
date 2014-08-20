namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceListRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceListRequest",
                c => new
                    {
                        PriceListRequestId = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        TaxId = c.String(),
                        BusinessAreaSelection = c.String(),
                    })
                .PrimaryKey(t => t.PriceListRequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PriceListRequest");
        }
    }
}
