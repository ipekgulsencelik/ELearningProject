namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "IsPopular", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Status");
            DropColumn("dbo.Courses", "IsPopular");
            DropColumn("dbo.Courses", "IsHome");
        }
    }
}
