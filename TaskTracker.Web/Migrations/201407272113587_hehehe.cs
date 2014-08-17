namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehehe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "RTasks");
            DropTable("dbo.CreateTaskViewModels");
            DropTable("dbo.EditTaskViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditTaskViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Due = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreateTaskViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Due = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameTable(name: "dbo.RTasks", newName: "Tasks");
        }
    }
}
