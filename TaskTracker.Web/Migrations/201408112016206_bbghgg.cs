namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbghgg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryRTasks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        RTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.RTask_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.RTasks", t => t.RTask_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.RTask_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryRTasks", "RTask_Id", "dbo.RTasks");
            DropForeignKey("dbo.CategoryRTasks", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryRTasks", new[] { "RTask_Id" });
            DropIndex("dbo.CategoryRTasks", new[] { "Category_Id" });
            DropTable("dbo.CategoryRTasks");
            DropTable("dbo.Categories");
        }
    }
}
