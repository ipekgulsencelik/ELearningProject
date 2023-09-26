namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_contact1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "Title", c => c.String());
            AddColumn("dbo.ContactInfoes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "Description");
            DropColumn("dbo.ContactInfoes", "Title");
        }
    }
}
