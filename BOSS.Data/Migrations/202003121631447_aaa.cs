namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedBy", c => c.Int());
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Products", "MetaKeyword", c => c.String());
            AddColumn("dbo.Products", "MetaDescription", c => c.String());
            AddColumn("dbo.Products", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "MetaDescription");
            DropColumn("dbo.Products", "MetaKeyword");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Products", "CreatedDate");
        }
    }
}
