namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_birles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "CategoryId");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropColumn("dbo.Projects", "CategoryId");
        }
    }
}
