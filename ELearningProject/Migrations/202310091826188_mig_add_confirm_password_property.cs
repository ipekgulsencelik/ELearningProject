namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_confirm_password_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Students", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Instructors", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "ConfirmPassword");
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Students", "ConfirmPassword");
            DropColumn("dbo.Admins", "ConfirmPassword");
        }
    }
}
