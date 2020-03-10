namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.ProductCategories", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.PostCategories", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductCategories", "Status", c => c.Boolean(nullable: false));
            DropTable("dbo.Comments");
        }
    }
}
