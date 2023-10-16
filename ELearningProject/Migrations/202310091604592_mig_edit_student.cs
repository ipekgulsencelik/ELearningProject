namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Students", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ImageURL");
            DropColumn("dbo.Students", "PhoneNumber");
        }
    }
}
