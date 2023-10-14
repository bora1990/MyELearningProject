namespace MyELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class las1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testimonials", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Testimonials", "Image");
        }
    }
}
