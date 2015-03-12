namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnhancements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 25),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.CustomerOrder",
                c => new
                    {
                        CustomerOrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerOrderId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        MiddleName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        GadgetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Gadget", t => t.GadgetId, cascadeDelete: true)
                .Index(t => t.GadgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "GadgetId", "dbo.Gadget");
            DropForeignKey("dbo.CustomerOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "AddressId", "dbo.Address");
            DropIndex("dbo.Order", new[] { "GadgetId" });
            DropIndex("dbo.Customer", new[] { "AddressId" });
            DropIndex("dbo.CustomerOrder", new[] { "OrderId" });
            DropIndex("dbo.CustomerOrder", new[] { "CustomerId" });
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerOrder");
            DropTable("dbo.Address");
        }
    }
}