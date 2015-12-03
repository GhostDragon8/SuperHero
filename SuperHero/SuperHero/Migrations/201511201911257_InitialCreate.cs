namespace SuperHero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        HeroName = c.String(),
                        UserName = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        ProfileID = c.Int(nullable: false),
                        ProfID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Profiles", t => t.ProfID)
                .Index(t => t.ProfID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfID = c.Int(nullable: false, identity: true),
                        Bio = c.String(),
                        MemID = c.Int(nullable: false),
                        Demographics_DemID = c.Int(),
                        Interests_InterestID = c.Int(),
                        Photos_PhotoID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfID)
                .ForeignKey("dbo.Demographics", t => t.Demographics_DemID)
                .ForeignKey("dbo.Interests", t => t.Interests_InterestID)
                .ForeignKey("dbo.Photos", t => t.Photos_PhotoID)
                .Index(t => t.Demographics_DemID)
                .Index(t => t.Interests_InterestID)
                .Index(t => t.Photos_PhotoID);
            
            CreateTable(
                "dbo.Demographics",
                c => new
                    {
                        DemID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.DemID);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InterestID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        ProfilePic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Photos_PhotoID", "dbo.Photos");
            DropForeignKey("dbo.Members", "ProfID", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Interests_InterestID", "dbo.Interests");
            DropForeignKey("dbo.Profiles", "Demographics_DemID", "dbo.Demographics");
            DropIndex("dbo.Profiles", new[] { "Photos_PhotoID" });
            DropIndex("dbo.Profiles", new[] { "Interests_InterestID" });
            DropIndex("dbo.Profiles", new[] { "Demographics_DemID" });
            DropIndex("dbo.Members", new[] { "ProfID" });
            DropTable("dbo.Photos");
            DropTable("dbo.Interests");
            DropTable("dbo.Demographics");
            DropTable("dbo.Profiles");
            DropTable("dbo.Members");
        }
    }
}
