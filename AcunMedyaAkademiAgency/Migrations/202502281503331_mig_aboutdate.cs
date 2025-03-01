namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aboutdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Date");
        }
    }
}
