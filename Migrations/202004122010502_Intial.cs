namespace TuLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Author = c.String(nullable: false, maxLength: 50),
                        DownloadTimes = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        puplisher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book_Language", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.puplisher_Id)
                .ForeignKey("dbo.Book_Type", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.TypeId)
                .Index(t => t.puplisher_Id);
            
            CreateTable(
                "dbo.Book_Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "TypeId", "dbo.Book_Type");
            DropForeignKey("dbo.Books", "puplisher_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Books", "LanguageId", "dbo.Book_Language");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Books", new[] { "puplisher_Id" });
            DropIndex("dbo.Books", new[] { "TypeId" });
            DropIndex("dbo.Books", new[] { "LanguageId" });
            DropTable("dbo.Book_Type");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Book_Language");
            DropTable("dbo.Books");
        }
    }
}
