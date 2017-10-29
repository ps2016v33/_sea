namespace SeaBattle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        HashPassword = c.String(nullable: false),
                        Salt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserAccountId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Login = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserAccountId)
                .ForeignKey("dbo.UserAccount", t => t.UserAccountId)
                .Index(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAccountId", "dbo.UserAccount");
            DropIndex("dbo.Users", new[] { "UserAccountId" });
            DropIndex("dbo.UserAccount", new[] { "Email" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAccount");
        }
    }
}
