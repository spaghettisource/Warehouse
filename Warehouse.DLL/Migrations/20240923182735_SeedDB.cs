using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DAL.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "IsHazardous", "ProductName", "SizePerUnit" },
                values: new object[,]
                {
                    { 1, false, "Laptop", 15.6f },
                    { 2, false, "Smartphone", 6.1f },
                    { 3, true, "Lithium Battery", 0.5f }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseID", "IsHazardousOnly", "MaxStockAmount", "WarehouseName" },
                values: new object[,]
                {
                    { 1, false, 0f, "New York" },
                    { 2, false, 0f, "New York" },
                    { 3, false, 0f, "Chicago" }
                });

            migrationBuilder.InsertData(
                table: "StockMovements",
                columns: new[] { "MovementID", "Amount", "Date", "IsImport", "ProductID", "WarehouseID" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 1 });

            migrationBuilder.InsertData(
                table: "StockMovements",
                columns: new[] { "MovementID", "Amount", "Date", "IsImport", "ProductID", "WarehouseID" },
                values: new object[] { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 2 });

            migrationBuilder.InsertData(
                table: "StockMovements",
                columns: new[] { "MovementID", "Amount", "Date", "IsImport", "ProductID", "WarehouseID" },
                values: new object[] { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StockMovements",
                keyColumn: "MovementID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockMovements",
                keyColumn: "MovementID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockMovements",
                keyColumn: "MovementID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "WarehouseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "WarehouseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "WarehouseID",
                keyValue: 3);
        }
    }
}
