namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_relations_comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "CourseID");
            AddForeignKey("dbo.Comments", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Comments", new[] { "CourseID" });
            DropColumn("dbo.Comments", "CourseID");
        }
    }
}
