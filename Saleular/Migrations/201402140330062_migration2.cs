namespace Saleular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget");
            DropForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget");
            DropIndex("dbo.Phones", new[] { "GadgetID" });
            DropIndex("dbo.Tablets", new[] { "GadgetID" });
            AddColumn("dbo.Gadget", "Type", c => c.String(maxLength: 25));
            AddColumn("dbo.Gadget", "Model", c => c.String(maxLength: 10));
            AddColumn("dbo.Tablets", "IsWiFiOnly", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tablets", "Carrier", c => c.String());
            CreateIndex("dbo.Phones", "GadgetID");
            CreateIndex("dbo.Tablets", "GadgetID");
            AddForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget", "GadgetID");
            AddForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget", "GadgetID");
            DropColumn("dbo.Phones", "Type");
            DropColumn("dbo.Phones", "Model");
            DropColumn("dbo.Tablets", "Type");
            DropColumn("dbo.Tablets", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tablets", "Model", c => c.String(maxLength: 10));
            AddColumn("dbo.Tablets", "Type", c => c.String(maxLength: 25));
            AddColumn("dbo.Phones", "Model", c => c.String(maxLength: 10));
            AddColumn("dbo.Phones", "Type", c => c.String(maxLength: 25));
            DropForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget");
            DropForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget");
            DropIndex("dbo.Tablets", new[] { "GadgetID" });
            DropIndex("dbo.Phones", new[] { "GadgetID" });
            DropColumn("dbo.Tablets", "Carrier");
            DropColumn("dbo.Tablets", "IsWiFiOnly");
            DropColumn("dbo.Gadget", "Model");
            DropColumn("dbo.Gadget", "Type");
            CreateIndex("dbo.Tablets", "GadgetID");
            CreateIndex("dbo.Phones", "GadgetID");
            AddForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget", "GadgetID");
            AddForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget", "GadgetID");
        }
    }
}
