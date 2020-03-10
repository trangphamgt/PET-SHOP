namespace BOSS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentId", c => c.Int());
            AddColumn("dbo.Comments", "PostId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "PostId");
            DropColumn("dbo.Comments", "CommentId");
        }
    }
}
