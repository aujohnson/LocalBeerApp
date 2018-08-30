namespace LocalBeer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brewery",
                c => new
                    {
                        BreweryName = c.String(nullable: false, maxLength: 128),
                        BreweryId = c.Int(nullable: false),
                        BreweryAddress = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        BreweryDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BreweryName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brewery");
        }
    }
}
