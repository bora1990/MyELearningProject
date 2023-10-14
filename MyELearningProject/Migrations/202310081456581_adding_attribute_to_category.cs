namespace MyELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_attribute_to_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryPhoto");
        }
    }
}
