using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderItem_Tenders_TenderId",
                table: "TenderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderItem_TenderResponses_TenderResponseId",
                table: "TenderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderItem",
                table: "TenderItem");

            migrationBuilder.RenameTable(
                name: "TenderItem",
                newName: "TenderItems");

            migrationBuilder.RenameIndex(
                name: "IX_TenderItem_TenderResponseId",
                table: "TenderItems",
                newName: "IX_TenderItems_TenderResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_TenderItem_TenderId",
                table: "TenderItems",
                newName: "IX_TenderItems_TenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderItems",
                table: "TenderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderItems_Tenders_TenderId",
                table: "TenderItems",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderItems_TenderResponses_TenderResponseId",
                table: "TenderItems",
                column: "TenderResponseId",
                principalTable: "TenderResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderItems_Tenders_TenderId",
                table: "TenderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderItems_TenderResponses_TenderResponseId",
                table: "TenderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderItems",
                table: "TenderItems");

            migrationBuilder.RenameTable(
                name: "TenderItems",
                newName: "TenderItem");

            migrationBuilder.RenameIndex(
                name: "IX_TenderItems_TenderResponseId",
                table: "TenderItem",
                newName: "IX_TenderItem_TenderResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_TenderItems_TenderId",
                table: "TenderItem",
                newName: "IX_TenderItem_TenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderItem",
                table: "TenderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderItem_Tenders_TenderId",
                table: "TenderItem",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderItem_TenderResponses_TenderResponseId",
                table: "TenderItem",
                column: "TenderResponseId",
                principalTable: "TenderResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
