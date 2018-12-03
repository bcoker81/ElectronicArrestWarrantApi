namespace ElectronicArrestWarrantApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabaseCreationv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        AddressType = c.String(),
                        FkPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Persons", t => t.FkPersonId, cascadeDelete: true)
                .Index(t => t.FkPersonId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AliasName = c.String(),
                        SafeAtHomeNumber = c.String(),
                        DriversLicenseNumber = c.String(),
                        DriversLicenseIssuingStateCode = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Ssn = c.String(),
                        StateIdNumber = c.String(),
                        PersonType = c.String(),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Race = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        FkEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Entries", t => t.FkEntryId, cascadeDelete: true)
                .Index(t => t.FkEntryId);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        BondAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BondAdditionalText = c.String(),
                        WarrantNumber = c.String(),
                        SigningJudge = c.String(),
                        WarrantAdditionalText = c.String(),
                        IssuingCourtOri = c.String(),
                        CourtMasterCaseNumber = c.String(),
                        ServicingOri = c.String(),
                    })
                .PrimaryKey(t => t.EntryId);
            
            CreateTable(
                "dbo.Charges",
                c => new
                    {
                        ChargesId = c.Int(nullable: false, identity: true),
                        ChargeCodeDescStatuteNumber = c.String(),
                        ChargeCodeNcicMod = c.String(),
                        LongDescription = c.String(),
                        ChargeDate = c.DateTime(nullable: false),
                        ChargeLevel = c.String(),
                        IssuingCourtCounty = c.String(),
                        IssuingCourtJurisdiction = c.String(),
                        CaseesAssignedJudgeNameMobar = c.String(),
                        ServicingLawEnforcementOri = c.String(),
                        CaseOcnNumber = c.String(),
                        ImageOfWarrantDoc = c.String(),
                        FkEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChargesId)
                .ForeignKey("dbo.Entries", t => t.FkEntryId, cascadeDelete: true)
                .Index(t => t.FkEntryId);
            
            CreateTable(
                "dbo.SupplementalNames",
                c => new
                    {
                        SupplementalNameId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        FkPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplementalNameId)
                .ForeignKey("dbo.Persons", t => t.FkPersonId, cascadeDelete: true)
                .Index(t => t.FkPersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "FkPersonId", "dbo.Persons");
            DropForeignKey("dbo.SupplementalNames", "FkPersonId", "dbo.Persons");
            DropForeignKey("dbo.Persons", "FkEntryId", "dbo.Entries");
            DropForeignKey("dbo.Charges", "FkEntryId", "dbo.Entries");
            DropIndex("dbo.SupplementalNames", new[] { "FkPersonId" });
            DropIndex("dbo.Charges", new[] { "FkEntryId" });
            DropIndex("dbo.Persons", new[] { "FkEntryId" });
            DropIndex("dbo.Addresses", new[] { "FkPersonId" });
            DropTable("dbo.SupplementalNames");
            DropTable("dbo.Charges");
            DropTable("dbo.Entries");
            DropTable("dbo.Persons");
            DropTable("dbo.Addresses");
        }
    }
}
