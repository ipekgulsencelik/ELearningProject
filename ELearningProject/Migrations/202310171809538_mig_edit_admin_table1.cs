namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_admin_table1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "PhoneNumber");
        }
    }
}
