using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PPStore.Migrations
{
    public partial class AddMultiPizzaOrderAndAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Address_AddressID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pizzas_PizzaID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PizzaID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PizzaCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PizzaID",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PpUserId",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    UnitCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.OrderId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PpUserId",
                table: "Orders",
                column: "PpUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressID",
                table: "AspNetUsers",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressID",
                table: "AspNetUsers",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_PpUserId",
                table: "Orders",
                column: "PpUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_PpUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PpUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PpUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaCount",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PizzaID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressID",
                table: "Orders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaID",
                table: "Orders",
                column: "PizzaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Address_AddressID",
                table: "Orders",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pizzas_PizzaID",
                table: "Orders",
                column: "PizzaID",
                principalTable: "Pizzas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
