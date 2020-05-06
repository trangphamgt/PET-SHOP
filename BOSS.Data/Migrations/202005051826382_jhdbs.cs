namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jhdbs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ParentId", c => c.Int());
            DropColumn("dbo.Menus", "GroupID");
            DropTable("dbo.MenuGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "GroupID", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "ParentId");
        }
    }
}
