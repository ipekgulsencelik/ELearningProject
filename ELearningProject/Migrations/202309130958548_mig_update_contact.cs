namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoes", "Status");
        }
    }
}
