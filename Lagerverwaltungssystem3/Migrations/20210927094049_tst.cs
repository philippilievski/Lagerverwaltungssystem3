using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltungssystem3.Migrations
{
    public partial class tst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_EntryExit_EntryExitID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryExit",
                table: "EntryExit");

            migrationBuilder.RenameTable(
                name: "EntryExit",
                newName: "EntryExits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryExits",
                table: "EntryExits",
                column: "EntryExitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_EntryExits_EntryExitID",
                table: "Orders",
                column: "EntryExitID",
                principalTable: "EntryExits",
                principalColumn: "EntryExitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_EntryExits_EntryExitID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryExits",
                table: "EntryExits");

            migrationBuilder.RenameTable(
                name: "EntryExits",
                newName: "EntryExit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryExit",
                table: "EntryExit",
                column: "EntryExitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_EntryExit_EntryExitID",
                table: "Orders",
                column: "EntryExitID",
                principalTable: "EntryExit",
                principalColumn: "EntryExitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
