namespace SeaBattle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Verify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccount", "IsActivated", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserAccount", "VerifyCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccount", "VerifyCode");
            DropColumn("dbo.UserAccount", "IsActivated");
        }
    }
}
