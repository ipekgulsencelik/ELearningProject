﻿namespace ELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Status");
        }
    }
}
