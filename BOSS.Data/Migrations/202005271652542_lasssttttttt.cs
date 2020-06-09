namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lasssttttttt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups");
            DropIndex("dbo.Menus", new[] { "GroupId" });
            DropColumn("dbo.Menus", "ParentId");
            DropColumn("dbo.Menus", "GroupId");
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
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "GroupId", c => c.Int());
            AddColumn("dbo.Menus", "ParentId", c => c.Int());
            CreateIndex("dbo.Menus", "GroupId");
            AddForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups", "Id");
        }
    }
}
