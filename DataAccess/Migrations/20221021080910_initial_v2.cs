using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ProcutAmount",
                table: "Payments",
                newName: "ProductAmount");


            migrationBuilder.CreateTable(
                name: "TableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "ProductAmount",
                table: "Payments",
                newName: "ProcutAmount");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
