namespace TuLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "puplisher_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "puplisher_Id" });
            DropColumn("dbo.Books", "PublisherId");
            RenameColumn(table: "dbo.Books", name: "puplisher_Id", newName: "PublisherId");
            AlterColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Users");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "PublisherId", newName: "puplisher_Id");
            AddColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "puplisher_Id");
            AddForeignKey("dbo.Books", "puplisher_Id", "dbo.Users", "Id");
        }
    }
}
