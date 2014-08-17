namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CreateTaskViewModels", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreateTaskViewModels", "Created", c => c.DateTime(nullable: false));
        }
    }
}
