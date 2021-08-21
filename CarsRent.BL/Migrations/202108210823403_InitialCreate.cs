namespace CarsRent.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        Year = c.String(),
                        PassportSeries = c.String(),
                        PassportNumber = c.String(),
                        VIN = c.String(),
                        BodyNumber = c.String(),
                        RegistrationNumber = c.String(),
                        EngineNumber = c.String(),
                        EngineDisplacement = c.String(),
                        Price = c.Double(nullable: false),
                        PassportIssuingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConclusionDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Car_Id = c.Long(),
                        LandLord_Id = c.Long(),
                        Renter_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.LandLords", t => t.LandLord_Id)
                .ForeignKey("dbo.Renters", t => t.Renter_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.LandLord_Id)
                .Index(t => t.Renter_Id);
            
            CreateTable(
                "dbo.LandLords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Passport_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passports", t => t.Passport_Id)
                .Index(t => t.Passport_Id);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Series = c.String(),
                        Number = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        IssuingOrganization = c.String(),
                        RegistrationPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Passport_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passports", t => t.Passport_Id)
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
