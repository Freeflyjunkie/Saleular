namespace Saleular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phone", "ImageUrl", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phone", "ImageUrl", c => c.String(maxLength: 300));
        }
    }
}
