namespace SuperHero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMemberProp : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Members");
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        DateFriended = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Recipient = c.String(),
                        MessageText = c.String(),
                        DateSent = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                        ThreadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            AddColumn("dbo.Members", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Members", "MessageID", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "MemberID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Members", "ID");
            CreateIndex("dbo.Members", "MemberID");
            CreateIndex("dbo.Members", "MessageID");
            AddForeignKey("dbo.Members", "MemberID", "dbo.Friends", "MemberID", cascadeDelete: true);
            AddForeignKey("dbo.Members", "MessageID", "dbo.Messages", "MessageID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "MessageID", "dbo.Messages");
            DropForeignKey("dbo.Members", "MemberID", "dbo.Friends");
            DropIndex("dbo.Members", new[] { "MessageID" });
            DropIndex("dbo.Members", new[] { "MemberID" });
            DropPrimaryKey("dbo.Members");
            AlterColumn("dbo.Members", "MemberID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Members", "MessageID");
            DropColumn("dbo.Members", "ID");
            DropTable("dbo.Messages");
            DropTable("dbo.Friends");
            AddPrimaryKey("dbo.Members", "MemberID");
        }
    }
}
