namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "AuthorId", c => c.Int());
            CreateIndex("dbo.Contents", "AuthorId");
            AddForeignKey("dbo.Contents", "AuthorId", "dbo.Authors", "AuthorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Contents", new[] { "AuthorId" });
            DropColumn("dbo.Contents", "AuthorId");
        }
    }
}
