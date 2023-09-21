namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_service : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Icon", c => c.Int(nullable: false));
        }
    }
}
