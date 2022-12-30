namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompanies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Companies", "JobsIDs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "JobsIDs", c => c.Int());
        }
    }
}
