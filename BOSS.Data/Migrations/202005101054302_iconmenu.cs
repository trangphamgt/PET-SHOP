namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iconmenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Icon");
        }
    }
}
