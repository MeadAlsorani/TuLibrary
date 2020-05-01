namespace TuLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookPath");
        }
    }
}
