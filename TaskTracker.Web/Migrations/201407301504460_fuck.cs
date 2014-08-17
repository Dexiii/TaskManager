namespace TaskTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RTasks", "Regarding_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RTasks", "Regarding_Id");
            AddForeignKey("dbo.RTasks", "Regarding_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RTasks", "Regarding_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RTasks", new[] { "Regarding_Id" });
            DropColumn("dbo.RTasks", "Regarding_Id");
        }
    }
}
