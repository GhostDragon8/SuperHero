namespace SuperHero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProfProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Demographics_DemID", "dbo.Demographics");
            DropForeignKey("dbo.Profiles", "Interests_InterestID", "dbo.Interests");
            DropForeignKey("dbo.Profiles", "Photos_PhotoID", "dbo.Photos");
            DropIndex("dbo.Profiles", new[] { "Demographics_DemID" });
            DropIndex("dbo.Profiles", new[] { "Interests_InterestID" });
            DropIndex("dbo.Profiles", new[] { "Photos_PhotoID" });
            RenameColumn(table: "dbo.Profiles", name: "Demographics_DemID", newName: "DemID");
            RenameColumn(table: "dbo.Profiles", name: "Interests_InterestID", newName: "InterestID");
            RenameColumn(table: "dbo.Profiles", name: "Photos_PhotoID", newName: "PhotoID");
            AlterColumn("dbo.Profiles", "DemID", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "InterestID", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "PhotoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Profiles", "DemID");
            CreateIndex("dbo.Profiles", "InterestID");
            CreateIndex("dbo.Profiles", "PhotoID");
            AddForeignKey("dbo.Profiles", "DemID", "dbo.Demographics", "DemID", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "InterestID", "dbo.Interests", "InterestID", cascadeDelete: true);
            AddForeignKey("dbo.Profiles", "PhotoID", "dbo.Photos", "PhotoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "PhotoID", "dbo.Photos");
            DropForeignKey("dbo.Profiles", "InterestID", "dbo.Interests");
            DropForeignKey("dbo.Profiles", "DemID", "dbo.Demographics");
            DropIndex("dbo.Profiles", new[] { "PhotoID" });
            DropIndex("dbo.Profiles", new[] { "InterestID" });
            DropIndex("dbo.Profiles", new[] { "DemID" });
            AlterColumn("dbo.Profiles", "PhotoID", c => c.Int());
            AlterColumn("dbo.Profiles", "InterestID", c => c.Int());
            AlterColumn("dbo.Profiles", "DemID", c => c.Int());
            RenameColumn(table: "dbo.Profiles", name: "PhotoID", newName: "Photos_PhotoID");
            RenameColumn(table: "dbo.Profiles", name: "InterestID", newName: "Interests_InterestID");
            RenameColumn(table: "dbo.Profiles", name: "DemID", newName: "Demographics_DemID");
            CreateIndex("dbo.Profiles", "Photos_PhotoID");
            CreateIndex("dbo.Profiles", "Interests_InterestID");
            CreateIndex("dbo.Profiles", "Demographics_DemID");
            AddForeignKey("dbo.Profiles", "Photos_PhotoID", "dbo.Photos", "PhotoID");
            AddForeignKey("dbo.Profiles", "Interests_InterestID", "dbo.Interests", "InterestID");
            AddForeignKey("dbo.Profiles", "Demographics_DemID", "dbo.Demographics", "DemID");
        }
    }
}
