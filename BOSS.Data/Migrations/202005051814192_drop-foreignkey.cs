namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropIndex("dbo.Menus", new[] { "GroupID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Menus", "GroupID");
            AddForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups", "Id", cascadeDelete: true);
        }
    }
}
