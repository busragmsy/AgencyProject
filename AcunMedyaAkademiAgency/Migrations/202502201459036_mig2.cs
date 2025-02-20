namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Registers");
        }
        
        public override void Down()
        {
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
    }
}
