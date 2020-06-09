namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastmenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ParentId", c => c.Int());
            AddColumn("dbo.Menus", "UserRole", c => c.Int(nullable: false));
            DropColumn("dbo.MenuGroups", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuGroups", "UserRole", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "UserRole");
            DropColumn("dbo.Menus", "ParentId");
        }
    }
}
