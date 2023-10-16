namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_instructor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructors", "PhoneNumber");
        }
    }
}
