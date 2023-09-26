namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_testimonial_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testimonials", "IsHome", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testimonials", "IsHome");
        }
    }
}
