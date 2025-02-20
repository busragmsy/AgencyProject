namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        RegisterId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.RegisterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registers");
            DropTable("dbo.Branches");
            DropTable("dbo.Admins");
        }
    }
}
