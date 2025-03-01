namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_iliski : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Gender", c => c.String());
            AddColumn("dbo.Teams", "City", c => c.String());
            AddColumn("dbo.Teams", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "BranchId");
            AddForeignKey("dbo.Teams", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "BranchId", "dbo.Branches");
            DropIndex("dbo.Teams", new[] { "BranchId" });
            DropColumn("dbo.Teams", "BranchId");
            DropColumn("dbo.Teams", "City");
            DropColumn("dbo.Teams", "Gender");
        }
    }
}
