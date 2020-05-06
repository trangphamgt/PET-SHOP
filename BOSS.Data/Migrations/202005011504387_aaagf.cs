namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaagf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "IsAdmin");
        }
    }
}
