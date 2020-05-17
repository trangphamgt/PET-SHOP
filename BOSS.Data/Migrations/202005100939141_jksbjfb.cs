namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jksbjfb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuGroups", "UserRole", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "GroupId", c => c.Int());
            CreateIndex("dbo.Menus", "GroupId");
            AddForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups", "Id");
            DropColumn("dbo.MenuGroups", "IsAdmin");
            DropColumn("dbo.MenuGroups", "Icon");
            DropColumn("dbo.Menus", "IsAdmin");
            DropColumn("dbo.Menus", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "ParentId", c => c.Int());
            AddColumn("dbo.Menus", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.MenuGroups", "Icon", c => c.String());
            AddColumn("dbo.MenuGroups", "IsAdmin", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups");
            DropIndex("dbo.Menus", new[] { "GroupId" });
            DropColumn("dbo.Menus", "GroupId");
            DropColumn("dbo.MenuGroups", "UserRole");
        }
    }
}
