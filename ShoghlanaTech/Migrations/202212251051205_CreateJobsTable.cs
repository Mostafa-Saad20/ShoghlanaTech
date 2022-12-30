﻿namespace ShoghlanaTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateJobsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Salary = c.String(),
                        YearsOfExp = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryID" });
            DropTable("dbo.Jobs");
        }
    }
}
