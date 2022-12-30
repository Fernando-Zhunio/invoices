using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoices.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sku_attachments_AttachmentId",
                table: "sku");

            migrationBuilder.DropIndex(
                name: "IX_sku_AttachmentId",
                table: "sku");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "sku");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkuId",
                table: "attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_ClientId",
                table: "invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_attachments_SkuId",
                table: "attachments",
                column: "SkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_attachments_sku_SkuId",
                table: "attachments",
                column: "SkuId",
                principalTable: "sku",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_clients_ClientId",
                table: "invoices",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attachments_sku_SkuId",
                table: "attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_invoices_clients_ClientId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_invoices_ClientId",
                table: "invoices");

            migrationBuilder.DropIndex(
                name: "IX_attachments_SkuId",
                table: "attachments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "SkuId",
                table: "attachments");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "sku",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sku_AttachmentId",
                table: "sku",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_sku_attachments_AttachmentId",
                table: "sku",
                column: "AttachmentId",
                principalTable: "attachments",
                principalColumn: "Id");
        }
    }
}
