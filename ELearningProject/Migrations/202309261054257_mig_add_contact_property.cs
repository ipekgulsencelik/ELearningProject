namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contact_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "SocialMedia1", c => c.String());
            AddColumn("dbo.ContactInfoes", "SocialMedia2", c => c.String());
            AddColumn("dbo.ContactInfoes", "SocialMedia3", c => c.String());
            AddColumn("dbo.ContactInfoes", "SocialMedia4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "SocialMedia4");
            DropColumn("dbo.ContactInfoes", "SocialMedia3");
            DropColumn("dbo.ContactInfoes", "SocialMedia2");
            DropColumn("dbo.ContactInfoes", "SocialMedia1");
        }
    }
}
