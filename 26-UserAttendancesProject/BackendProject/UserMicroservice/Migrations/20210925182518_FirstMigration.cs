using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroservice.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalAttendance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Nickname", "Password", "TotalAttendance" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perez", "Pedro", "pedro7", "123", 0 },
                    { 2, new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perez", "Maria", "maria7", "123", 0 },
                    { 3, new DateTime(2001, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perez", "Gabriela", "gabriela7", "123", 0 },
                    { 4, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perez", "Galia", "galia7", "123", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
