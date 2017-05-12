namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres ( GenreID, GenreName) VALUES(1,'Comdey')");
            Sql("INSERT INTO Genres ( GenreID, GenreName) VALUES(2,'Action')");
            Sql("INSERT INTO Genres ( GenreID, GenreName) VALUES(3,'Drama')");
            Sql("INSERT INTO Genres ( GenreID, GenreName) VALUES(4,'Thriller')");

        }
        
        public override void Down()
        {
        }
    }
}
