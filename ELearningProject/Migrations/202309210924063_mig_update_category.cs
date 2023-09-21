namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageURL", c => c.String());
            AddColumn("dbo.Categories", "IsHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Status");
            DropColumn("dbo.Categories", "IsHome");
            DropColumn("dbo.Categories", "ImageURL");
        }
    }
}
