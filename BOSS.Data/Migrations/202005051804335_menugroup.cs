namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menugroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuGroups", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuGroups", "IsAdmin");
        }
    }
}
