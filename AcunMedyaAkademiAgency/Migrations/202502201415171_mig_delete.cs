namespace AcunMedyaAkademiAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "Work");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Work", c => c.String());
        }
    }
}
