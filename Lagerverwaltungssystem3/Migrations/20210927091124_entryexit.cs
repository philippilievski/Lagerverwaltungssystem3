using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltungssystem3.Migrations
{
    public partial class entryexit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Deliverypositions");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "EntryExitID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                newName: "IX_Orders_EntryExitID");

            migrationBuilder.CreateTable(
                name: "EntryExit",
                columns: table => new
                {
                    EntryExitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryExit", x => x.EntryExitID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_EntryExit_EntryExitID",
                table: "Orders",
                column: "EntryExitID",
                principalTable: "EntryExit",
                principalColumn: "EntryExitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_EntryExit_EntryExitID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "EntryExit");

            migrationBuilder.RenameColumn(
                name: "EntryExitID",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EntryExitID",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_Deliveries_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deliverypositions",
                columns: table => new
                {
                    DeliverypositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryID = table.Column<int>(type: "int", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverypositions", x => x.DeliverypositionID);
                    table.ForeignKey(
                        name: "FK_Deliverypositions_Deliveries_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "DeliveryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliverypositions_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SupplierID",
                table: "Deliveries",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverypositions_DeliveryID",
                table: "Deliverypositions",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverypositions_ItemID",
                table: "Deliverypositions",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
