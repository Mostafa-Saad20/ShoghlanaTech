namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewColumnInJobs : DbMigration
    {
        public override void Up()
        {
            // DropForeignKey("dbo.Jobs", "CompID", "dbo.Companies");
            // DropIndex("dbo.Jobs", new[] { "CompID" });
            // DropColumn("dbo.Jobs", "CompID");
            AddColumn("dbo.Jobs", "CompanyID", c => c.String());
        }
        
        public override void Down()
        {
            // AddColumn("dbo.Jobs", "CompID", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "CompanyID");
            // CreateIndex("dbo.Jobs", "CompID");
            // AddForeignKey("dbo.Jobs", "CompID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
