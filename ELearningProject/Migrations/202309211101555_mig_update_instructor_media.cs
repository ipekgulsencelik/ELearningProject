namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_instructor_media : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "SocialMedia1", c => c.String());
            AddColumn("dbo.Instructors", "SocialMedia2", c => c.String());
            AddColumn("dbo.Instructors", "SocialMedia3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "SocialMedia3");
            DropColumn("dbo.Instructors", "SocialMedia2");
            DropColumn("dbo.Instructors", "SocialMedia1");
        }
    }
}
