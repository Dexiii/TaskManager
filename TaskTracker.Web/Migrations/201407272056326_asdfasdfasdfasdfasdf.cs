namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfasdfasdfasdfasdf : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EditTaskViewModels");
        }
    }
}
