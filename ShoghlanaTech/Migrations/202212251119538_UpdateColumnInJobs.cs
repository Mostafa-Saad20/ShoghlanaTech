namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInJobs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "YearsOfExp", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "YearsOfExp", c => c.Int(nullable: false));
        }
    }
}
