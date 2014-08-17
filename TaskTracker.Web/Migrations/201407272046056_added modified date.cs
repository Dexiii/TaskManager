namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodifieddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Modified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Modified");
        }
    }
}
