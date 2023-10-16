namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_video_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "UserID" });
            RenameColumn(table: "dbo.Courses", name: "UserID", newName: "User_UserID");
            RenameColumn(table: "dbo.Reviews", name: "UserID", newName: "User_UserID");
            RenameIndex(table: "dbo.Courses", name: "IX_UserID", newName: "IX_User_UserID");
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        LessonNumber = c.Int(nullable: false),
                        VideoURL = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            AlterColumn("dbo.Reviews", "User_UserID", c => c.Int());
            CreateIndex("dbo.Reviews", "User_UserID");
            AddForeignKey("dbo.Reviews", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Videos", "CourseID", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "CourseID" });
            DropIndex("dbo.Reviews", new[] { "User_UserID" });
            AlterColumn("dbo.Reviews", "User_UserID", c => c.Int(nullable: false));
            DropTable("dbo.Videos");
            RenameIndex(table: "dbo.Courses", name: "IX_User_UserID", newName: "IX_UserID");
            RenameColumn(table: "dbo.Reviews", name: "User_UserID", newName: "UserID");
            RenameColumn(table: "dbo.Courses", name: "User_UserID", newName: "UserID");
            CreateIndex("dbo.Reviews", "UserID");
            AddForeignKey("dbo.Reviews", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
