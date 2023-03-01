namespace InventoryTrackingWebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModifiedTimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryItems", "ModifiedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryItems", "ModifiedTime", c => c.DateTime(nullable: false));
        }
    }
}
