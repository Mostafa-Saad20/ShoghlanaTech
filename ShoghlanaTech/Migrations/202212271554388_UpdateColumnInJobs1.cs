namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInJobs1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "CompanyID", c => c.Int(nullable: true));
            CreateIndex("dbo.Jobs", "CompanyID");
            AddForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropColumn("dbo.Jobs", "CompanyID");
        }
    }
}
