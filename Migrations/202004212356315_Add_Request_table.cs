namespace TuLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Request_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publisher_Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Request_Text = c.String(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publisher_Requests", "PublisherId", "dbo.Users");
            DropIndex("dbo.Publisher_Requests", new[] { "PublisherId" });
            DropTable("dbo.Publisher_Requests");
        }
    }
}
