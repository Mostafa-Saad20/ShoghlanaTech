namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInJobs3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "PublishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
