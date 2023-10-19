namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_student_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Status");
        }
    }
}
