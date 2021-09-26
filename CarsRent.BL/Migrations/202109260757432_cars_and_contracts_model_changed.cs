namespace CarsRent.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cars_and_contracts_model_changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "RideType", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "RidePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "RidePrice");
            DropColumn("dbo.Contracts", "RideType");
        }
    }
}
