namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "IsRead", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
        }
    }
}
