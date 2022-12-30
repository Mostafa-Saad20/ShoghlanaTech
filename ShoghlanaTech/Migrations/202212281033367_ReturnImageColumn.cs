namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnImageColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Image", c => c.String(nullable: false));
        }
    }
}
