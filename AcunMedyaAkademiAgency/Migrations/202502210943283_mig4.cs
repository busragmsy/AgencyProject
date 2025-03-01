namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectDetails", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectDetails", "ProjectId");
            AddForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            DropColumn("dbo.ProjectDetails", "ProjectName");
            DropColumn("dbo.ProjectDetails", "Title");
            DropColumn("dbo.ProjectDetails", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectDetails", "ImageUrl", c => c.String());
            AddColumn("dbo.ProjectDetails", "Title", c => c.String());
            AddColumn("dbo.ProjectDetails", "ProjectName", c => c.String());
            DropForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectDetails", new[] { "ProjectId" });
            DropColumn("dbo.ProjectDetails", "ProjectId");
        }
    }
}
