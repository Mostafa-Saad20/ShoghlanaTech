namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Website = c.String(),
                        EmpCount = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CompID", "dbo.Companies");
            DropIndex("dbo.Jobs", new[] { "CompID" });
            DropColumn("dbo.Jobs", "CompID");
            DropTable("dbo.Companies");
        }
    }
}
