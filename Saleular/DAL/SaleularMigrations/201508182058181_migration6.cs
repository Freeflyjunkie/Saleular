namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
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
                    TaxId = c.String(),
                    BusinessAreaSelection = c.String(),
                    Quantity = c.String(),
                    Model = c.String(),
                    Carrier = c.String(),
                    Capacity = c.String(),
                    Condition = c.String(),
                })
                .PrimaryKey(t => t.SellPhoneRequestId);            
        }
        
        public override void Down()
        {
           
        }
    }
}
