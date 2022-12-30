namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateTimeColumnInJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PublishDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "PublishDate");
        }
    }
}
