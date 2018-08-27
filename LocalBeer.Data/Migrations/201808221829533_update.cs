namespace LocalBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beer", "BeerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beer", "BeerName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
