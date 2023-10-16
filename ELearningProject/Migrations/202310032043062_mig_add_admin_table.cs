namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_admin_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "UserID", c => c.Int());
            CreateIndex("dbo.Courses", "UserID");
            AddForeignKey("dbo.Courses", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UserID", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "UserID" });
            DropColumn("dbo.Courses", "UserID");
        }
    }
}
