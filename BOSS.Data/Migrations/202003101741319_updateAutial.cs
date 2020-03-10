namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAutial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Comments", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Comments", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Comments", "Status", c => c.Int());
            AlterColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductCategories", "CreatedBy", c => c.Int());
            AlterColumn("dbo.ProductCategories", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.ProductCategories", "Status", c => c.Int());
            AlterColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.PostCategories", "CreatedBy", c => c.Int());
            AlterColumn("dbo.PostCategories", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.PostCategories", "Status", c => c.Int());
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Posts", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategories", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategories", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategories", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategories", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
