namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SellPhoneRequest");
            AddColumn("dbo.SellPhoneRequest", "SellPhoneRequestId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SellPhoneRequest", "SellPhoneRequestId");
            DropColumn("dbo.SellPhoneRequest", "PriceListRequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellPhoneRequest", "PriceListRequestId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.SellPhoneRequest");
            DropColumn("dbo.SellPhoneRequest", "SellPhoneRequestId");
            AddPrimaryKey("dbo.SellPhoneRequest", "PriceListRequestId");
        }
    }
}
