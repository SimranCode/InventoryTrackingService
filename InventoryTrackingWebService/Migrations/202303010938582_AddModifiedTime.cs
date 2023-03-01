namespace InventoryTrackingWebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifiedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryItems", "ModifiedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InventoryItems", "ModifiedTime");
        }
    }
}
