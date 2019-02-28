using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DijleZonenApi.Migrations
{
    public partial class AddAmountToBalanceTopup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_BalanceTopups_Customer2",
                table: "balancetopups");

            migrationBuilder.DropForeignKey(
                name: "fk_BalanceTopups_Customer1",
                table: "balancetopups");

            migrationBuilder.DropForeignKey(
                name: "fk_EventSubscription_Customer1",
                table: "eventsubscription");

            migrationBuilder.DropForeignKey(
                name: "fk_Order_Customer2",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_Order_Customer1",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_Order_Production",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_OrderLine_Order1",
                table: "orderline");

            migrationBuilder.DropForeignKey(
                name: "fk_Rollback_Customer1",
                table: "rollback");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "product",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 90,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order_id",
                table: "orderline",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "orderline",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "balancetopups",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_orderline_OrderId1",
                table: "orderline",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_balancetopups_customer_cashierId",
                table: "balancetopups",
                column: "cashierId",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_balancetopups_customer_Customer_id",
                table: "balancetopups",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventsubscription_customer_Customer_id",
                table: "eventsubscription",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_Cashier_id",
                table: "order",
                column: "Cashier_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_Customer_id",
                table: "order",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_production_Production_id",
                table: "order",
                column: "Production_id",
                principalTable: "production",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderline_order_OrderId1",
                table: "orderline",
                column: "OrderId1",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rollback_customer_Customer_id",
                table: "rollback",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_balancetopups_customer_cashierId",
                table: "balancetopups");

            migrationBuilder.DropForeignKey(
                name: "FK_balancetopups_customer_Customer_id",
                table: "balancetopups");

            migrationBuilder.DropForeignKey(
                name: "FK_eventsubscription_customer_Customer_id",
                table: "eventsubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_Cashier_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_Customer_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_production_Production_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_orderline_order_OrderId1",
                table: "orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_rollback_customer_Customer_id",
                table: "rollback");

            migrationBuilder.DropIndex(
                name: "IX_orderline_OrderId1",
                table: "orderline");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "orderline");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "balancetopups");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "product",
                maxLength: 90,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 90);

            migrationBuilder.AlterColumn<int>(
                name: "Order_id",
                table: "orderline",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "fk_BalanceTopups_Customer2",
                table: "balancetopups",
                column: "cashierId",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_BalanceTopups_Customer1",
                table: "balancetopups",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_EventSubscription_Customer1",
                table: "eventsubscription",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_Order_Customer2",
                table: "order",
                column: "Cashier_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_Order_Customer1",
                table: "order",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_Order_Production",
                table: "order",
                column: "Production_id",
                principalTable: "production",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_OrderLine_Order1",
                table: "orderline",
                column: "Order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_Rollback_Customer1",
                table: "rollback",
                column: "Customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
