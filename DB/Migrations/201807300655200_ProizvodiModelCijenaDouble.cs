namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProizvodiModelCijenaDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proizvodis", "Cijena", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvodis", "Cijena", c => c.Single(nullable: false));
        }
    }
}
