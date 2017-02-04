namespace Books.Web.DataContext.BookMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class librarySchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Books", newSchema: "library");
        }
        
        public override void Down()
        {
            MoveTable(name: "library.Books", newSchema: "dbo");
        }
    }
}
