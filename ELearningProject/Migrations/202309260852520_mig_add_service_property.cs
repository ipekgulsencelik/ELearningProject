namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_service_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "IsHome", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "IsHome");
        }
    }
}
