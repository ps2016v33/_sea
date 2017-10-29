namespace SeaBattle.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BattleField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BattleFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(nullable: false, storeType: "xml"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BattleFields");
        }
    }
}
