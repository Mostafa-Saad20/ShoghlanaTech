namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInCategories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String(nullable: false));
        }
    }
}
