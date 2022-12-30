namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsInCompaniesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Companies", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Password");
            DropColumn("dbo.Companies", "Email");
        }
    }
}
