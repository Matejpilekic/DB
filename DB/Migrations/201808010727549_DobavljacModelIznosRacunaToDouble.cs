namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DobavljacModelIznosRacunaToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ulazis", "IznosRacuna", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ulazis", "IznosRacuna", c => c.Single(nullable: false));
        }
    }
}
