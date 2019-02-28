using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DijleZonenApi.Migrations
{
    public partial class RequiredInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "product",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
               name: "name",
               table: "product",
               nullable: false,
               oldClrType: typeof(string),
               oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "inStock",
                table: "product",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "criticalStock",
                table: "product",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "product",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "inStock",
                table: "product",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "criticalStock",
                table: "product",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");
        }
    }
}
