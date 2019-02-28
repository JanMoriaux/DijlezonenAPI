using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DijleZonenApi.Migrations
{
    public partial class RemoveOrderlinesFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_OrderLine_Product1",
                table: "orderline");

            migrationBuilder.AddForeignKey(
                name: "FK_orderline_product_Product_id",
                table: "orderline",
                column: "Product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderline_product_Product_id",
                table: "orderline");

            migrationBuilder.AddForeignKey(
                name: "fk_OrderLine_Product1",
                table: "orderline",
                column: "Product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
