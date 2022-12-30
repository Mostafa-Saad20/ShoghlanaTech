namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewColumnInJobs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Type");
        }
    }
}
