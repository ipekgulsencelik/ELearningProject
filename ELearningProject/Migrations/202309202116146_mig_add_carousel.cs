namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_carousel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        CarouselID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarouselID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carousels");
        }
    }
}
