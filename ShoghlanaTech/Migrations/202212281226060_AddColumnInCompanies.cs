namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInCompanies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "JobsIDs", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "JobsIDs");
        }
    }
}
