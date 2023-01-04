using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invoices.Migrations
{
    public partial class okDtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemInvoice_invoices_InvoiceId",
                table: "itemInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_itemInvoice_sku_productId",
                table: "itemInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_sku_products_ProductId",
                table: "sku");

            migrationBuilder.DropForeignKey(
                name: "FK_sku_variations_VariationId",
                table: "sku");

            migrationBuilder.DropForeignKey(
                name: "FK_taxAndDiscountConditionals_taxAndDiscounts_TaxAndDiscountId",
                table: "taxAndDiscountConditionals");

            migrationBuilder.DropForeignKey(
                name: "FK_typeVariations_variations_VariationId",
                table: "typeVariations");

            migrationBuilder.DropIndex(
                name: "IX_itemInvoice_productId",
                table: "itemInvoice");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "itemInvoice");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "itemInvoice",
                newName: "Quantity");

            migrationBuilder.AlterColumn<int>(
                name: "VariationId",
                table: "typeVariations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "typeVariations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "typeVariations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "value",
                table: "taxAndDiscounts",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "taxAndDiscounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "taxAndDiscounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "taxAndDiscounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "taxAndDiscounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsPercentage",
                table: "taxAndDiscounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TaxAndDiscountId",
                table: "taxAndDiscountConditionals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VariationId",
                table: "sku",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "sku",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "sku",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "itemInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkuId",
                table: "itemInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "pricesHistorySku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkuId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pricesHistorySku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pricesHistorySku_sku_SkuId",
                        column: x => x.SkuId,
                        principalTable: "sku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taxAndDiscountInvoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TaxAndDiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxAndDiscountInvoice", x => new { x.InvoiceId, x.TaxAndDiscountId });
                    table.ForeignKey(
                        name: "FK_taxAndDiscountInvoice_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taxAndDiscountInvoice_taxAndDiscounts_TaxAndDiscountId",
                        column: x => x.TaxAndDiscountId,
                        principalTable: "taxAndDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemInvoice_SkuId",
                table: "itemInvoice",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_pricesHistorySku_SkuId",
                table: "pricesHistorySku",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_taxAndDiscountInvoice_TaxAndDiscountId",
                table: "taxAndDiscountInvoice",
                column: "TaxAndDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_itemInvoice_invoices_InvoiceId",
                table: "itemInvoice",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_itemInvoice_sku_SkuId",
                table: "itemInvoice",
                column: "SkuId",
                principalTable: "sku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sku_products_ProductId",
                table: "sku",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sku_variations_VariationId",
                table: "sku",
                column: "VariationId",
                principalTable: "variations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_taxAndDiscountConditionals_taxAndDiscounts_TaxAndDiscountId",
                table: "taxAndDiscountConditionals",
                column: "TaxAndDiscountId",
                principalTable: "taxAndDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_typeVariations_variations_VariationId",
                table: "typeVariations",
                column: "VariationId",
                principalTable: "variations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemInvoice_invoices_InvoiceId",
                table: "itemInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_itemInvoice_sku_SkuId",
                table: "itemInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_sku_products_ProductId",
                table: "sku");

            migrationBuilder.DropForeignKey(
                name: "FK_sku_variations_VariationId",
                table: "sku");

            migrationBuilder.DropForeignKey(
                name: "FK_taxAndDiscountConditionals_taxAndDiscounts_TaxAndDiscountId",
                table: "taxAndDiscountConditionals");

            migrationBuilder.DropForeignKey(
                name: "FK_typeVariations_variations_VariationId",
                table: "typeVariations");

            migrationBuilder.DropTable(
                name: "pricesHistorySku");

            migrationBuilder.DropTable(
                name: "taxAndDiscountInvoice");

            migrationBuilder.DropIndex(
                name: "IX_itemInvoice_SkuId",
                table: "itemInvoice");

            migrationBuilder.DropColumn(
                name: "IsPercentage",
                table: "taxAndDiscounts");

            migrationBuilder.DropColumn(
                name: "SkuId",
                table: "itemInvoice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "itemInvoice",
                newName: "quantity");

            migrationBuilder.AlterColumn<int>(
                name: "VariationId",
                table: "typeVariations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "typeVariations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "typeVariations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "value",
                table: "taxAndDiscounts",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "taxAndDiscounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "taxAndDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "taxAndDiscounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "taxAndDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxAndDiscountId",
                table: "taxAndDiscountConditionals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VariationId",
                table: "sku",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "sku",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "sku",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "itemInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "itemInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemInvoice_productId",
                table: "itemInvoice",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_itemInvoice_invoices_InvoiceId",
                table: "itemInvoice",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_itemInvoice_sku_productId",
                table: "itemInvoice",
                column: "productId",
                principalTable: "sku",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sku_products_ProductId",
                table: "sku",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sku_variations_VariationId",
                table: "sku",
                column: "VariationId",
                principalTable: "variations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taxAndDiscountConditionals_taxAndDiscounts_TaxAndDiscountId",
                table: "taxAndDiscountConditionals",
                column: "TaxAndDiscountId",
                principalTable: "taxAndDiscounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_typeVariations_variations_VariationId",
                table: "typeVariations",
                column: "VariationId",
                principalTable: "variations",
                principalColumn: "Id");
        }
    }
}
