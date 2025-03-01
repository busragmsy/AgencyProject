namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "SendDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "SendDate", c => c.String());
        }
    }
}
