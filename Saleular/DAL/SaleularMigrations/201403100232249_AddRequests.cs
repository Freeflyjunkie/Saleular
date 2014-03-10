namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        GadgetId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        State = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Gadget", t => t.GadgetId, cascadeDelete: true)
                .Index(t => t.GadgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "GadgetId", "dbo.Gadget");
            DropIndex("dbo.Request", new[] { "GadgetId" });
            DropTable("dbo.Request");
        }
    }
}
