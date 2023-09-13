namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_about : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Abouts", "Statue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Statue", c => c.Boolean(nullable: false));
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
