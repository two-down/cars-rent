namespace CarsRent.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingpassport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LandLords", "Passport_Id", "dbo.Passports");
            DropForeignKey("dbo.Renters", "Passport_Id", "dbo.Passports");
            DropIndex("dbo.LandLords", new[] { "Passport_Id" });
            DropIndex("dbo.Renters", new[] { "Passport_Id" });
            AddColumn("dbo.LandLords", "Name", c => c.String());
            AddColumn("dbo.LandLords", "Surname", c => c.String());
            AddColumn("dbo.LandLords", "Patronymic", c => c.String());
            AddColumn("dbo.LandLords", "Series", c => c.String());
            AddColumn("dbo.LandLords", "Number", c => c.String());
            AddColumn("dbo.LandLords", "IssueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LandLords", "IssuingOrganization", c => c.String());
            AddColumn("dbo.LandLords", "RegistrationPlace", c => c.String());
            AddColumn("dbo.Renters", "Name", c => c.String());
            AddColumn("dbo.Renters", "Surname", c => c.String());
            AddColumn("dbo.Renters", "Patronymic", c => c.String());
            AddColumn("dbo.Renters", "Series", c => c.String());
            AddColumn("dbo.Renters", "Number", c => c.String());
            AddColumn("dbo.Renters", "IssueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Renters", "IssuingOrganization", c => c.String());
            AddColumn("dbo.Renters", "RegistrationPlace", c => c.String());
            DropColumn("dbo.LandLords", "Passport_Id");
            DropColumn("dbo.Renters", "Passport_Id");
            DropTable("dbo.Passports");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Renters", "Passport_Id", c => c.Long());
            AddColumn("dbo.LandLords", "Passport_Id", c => c.Long());
            DropColumn("dbo.Renters", "RegistrationPlace");
            DropColumn("dbo.Renters", "IssuingOrganization");
            DropColumn("dbo.Renters", "IssueDate");
            DropColumn("dbo.Renters", "Number");
            DropColumn("dbo.Renters", "Series");
            DropColumn("dbo.Renters", "Patronymic");
            DropColumn("dbo.Renters", "Surname");
            DropColumn("dbo.Renters", "Name");
            DropColumn("dbo.LandLords", "RegistrationPlace");
            DropColumn("dbo.LandLords", "IssuingOrganization");
            DropColumn("dbo.LandLords", "IssueDate");
            DropColumn("dbo.LandLords", "Number");
            DropColumn("dbo.LandLords", "Series");
            DropColumn("dbo.LandLords", "Patronymic");
            DropColumn("dbo.LandLords", "Surname");
            DropColumn("dbo.LandLords", "Name");
            CreateIndex("dbo.Renters", "Passport_Id");
            CreateIndex("dbo.LandLords", "Passport_Id");
            AddForeignKey("dbo.Renters", "Passport_Id", "dbo.Passports", "Id");
            AddForeignKey("dbo.LandLords", "Passport_Id", "dbo.Passports", "Id");
        }
    }
}
