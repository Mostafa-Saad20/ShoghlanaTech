namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompanyIDJobs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            AlterColumn("dbo.Jobs", "CompanyID", c => c.Int());
            CreateIndex("dbo.Jobs", "CompanyID");
            AddForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            AlterColumn("dbo.Jobs", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CompanyID");
            AddForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
