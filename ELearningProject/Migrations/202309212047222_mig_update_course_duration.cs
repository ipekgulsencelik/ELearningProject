namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_course_duration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
        }
    }
}
