using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle_Project_CodeWithMosh.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // feeding the Databaase with values  Make table
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT  INTO Makes (Name) VALUES ('Make3')");


            // feeding the MOdel table
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make1-MOdelA',(SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make1-MOdelB',(SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make1-MOdelC',(SELECT ID FROM Makes WHERE Name = 'Make1'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make2-MOdelA',(SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make2-MOdelB',(SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make2-MOdelC',(SELECT ID FROM Makes WHERE Name = 'Make2'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make3-MOdelA',(SELECT ID FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make3-MOdelB',(SELECT ID FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('Make3-MOdelC',(SELECT ID FROM Makes WHERE Name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
