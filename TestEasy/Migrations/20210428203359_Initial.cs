using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEasy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkCRUD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Portfolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salaryPrefer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    willingnessWorkWeek = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    TimeWork = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Knowledge = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
                    OtherLanguageFramework = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_RegisterId",
                table: "Skills",
                column: "RegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Registers");
        }
    }
}
