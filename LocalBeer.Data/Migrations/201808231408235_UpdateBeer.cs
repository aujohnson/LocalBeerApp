namespace LocalBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBeer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "BeerType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beer", "BeerType");
        }
    }
}
