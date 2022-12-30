namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoriesNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Image");
        }
    }
}
