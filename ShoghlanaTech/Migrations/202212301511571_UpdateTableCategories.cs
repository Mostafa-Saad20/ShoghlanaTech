namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCategories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String());
        }
    }
}
