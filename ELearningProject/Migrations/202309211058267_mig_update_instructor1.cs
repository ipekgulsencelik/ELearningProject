namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_instructor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "IsHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Instructors", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "Status");
            DropColumn("dbo.Instructors", "IsHome");
        }
    }
}
