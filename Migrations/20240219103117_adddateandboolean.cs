using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seance2.Migrations
{
    public partial class adddateandboolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "relatedate",
                table: "movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "withsubtitels",
                table: "movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "relatedate",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "withsubtitels",
                table: "movies");
        }
    }
}
