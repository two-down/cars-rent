namespace CarsRent.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class global_model_changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        PassportSeries = c.String(nullable: false),
                        PassportNumber = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                        BodyNumber = c.String(nullable: false),
                        RegistrationNumber = c.String(nullable: false),
                        EngineNumber = c.String(nullable: false),
                        EngineDisplacement = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        PassportIssuingDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConclusionDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        RideType = c.Int(nullable: false),
                        RidePrice = c.String(nullable: false),
                        Car_Id = c.Long(nullable: false),
                        LandLord_Id = c.Long(nullable: false),
                        Renter_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.LandLords", t => t.LandLord_Id, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.Renter_Id, cascadeDelete: true)
                .Index(t => t.Car_Id)
                .Index(t => t.LandLord_Id)
                .Index(t => t.Renter_Id);
            
            CreateTable(
                "dbo.LandLords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Passport_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passports", t => t.Passport_Id, cascadeDelete: false)
                .Index(t => t.Passport_Id);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Patronymic = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        IssueDate = c.String(nullable: false),
                        IssuingOrganization = c.String(nullable: false),
                        RegistrationPlace = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Passport_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passports", t => t.Passport_Id, cascadeDelete: false)
                .Index(t => t.Passport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Renter_Id", "dbo.Renters");
            DropForeignKey("dbo.Renters", "Passport_Id", "dbo.Passports");
            DropForeignKey("dbo.Contracts", "LandLord_Id", "dbo.LandLords");
            DropForeignKey("dbo.LandLords", "Passport_Id", "dbo.Passports");
            DropForeignKey("dbo.Contracts", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Renters", new[] { "Passport_Id" });
            DropIndex("dbo.LandLords", new[] { "Passport_Id" });
            DropIndex("dbo.Contracts", new[] { "Renter_Id" });
            DropIndex("dbo.Contracts", new[] { "LandLord_Id" });
            DropIndex("dbo.Contracts", new[] { "Car_Id" });
            DropTable("dbo.Renters");
            DropTable("dbo.Passports");
            DropTable("dbo.LandLords");
            DropTable("dbo.Contracts");
            DropTable("dbo.Cars");
        }
    }
}
