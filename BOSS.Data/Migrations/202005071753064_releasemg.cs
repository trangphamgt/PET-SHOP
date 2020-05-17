namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class releasemg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        IsAdmin = c.Boolean(nullable: false),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuGroups");
        }
    }
}
