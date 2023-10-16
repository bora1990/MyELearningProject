namespace MyELearningProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_video_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "CourseID", "dbo.Courses");
            DropIndex("dbo.Videos", new[] { "CourseID" });
            DropTable("dbo.Videos");
        }
    }
}
