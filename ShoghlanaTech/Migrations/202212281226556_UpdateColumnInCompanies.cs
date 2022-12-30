namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInCompanies : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "JobsIDs", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "JobsIDs", c => c.Int(nullable: false));
        }
    }
}
