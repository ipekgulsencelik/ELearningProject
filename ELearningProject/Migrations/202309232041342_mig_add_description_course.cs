namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_description_course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Courses", "Description");
        }
    }
}
