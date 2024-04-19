using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seance2.Migrations
{
    public partial class addMembreship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memberShipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberShipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_memberShipts_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_memberShipts_CustomerId",
                table: "memberShipts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberShipts");
        }
    }
}
