using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DijleZonenApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creditBalance = table.Column<float>(nullable: true),
                    firstName = table.Column<string>(maxLength: 90, nullable: true),
                    hashedPass = table.Column<string>(maxLength: 45, nullable: true),
                    lastName = table.Column<string>(maxLength: 90, nullable: true),
                    role = table.Column<string>(maxLength: 45, nullable: true),
                    salt = table.Column<string>(maxLength: 45, nullable: true),
                    userName = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    subscriptionFee = table.Column<float>(nullable: false),
                    toDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    criticalStock = table.Column<int>(type: "int(11)", nullable: true),
                    imageUrl = table.Column<string>(maxLength: 135, nullable: true),
                    inStock = table.Column<int>(type: "int(11)", nullable: true),
                    name = table.Column<string>(maxLength: 90, nullable: true),
                    price = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "production",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_production", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "balancetopups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cashierId = table.Column<int>(type: "int(11)", nullable: false),
                    Customer_id = table.Column<int>(type: "int(11)", nullable: false),
                    Event_id = table.Column<int>(type: "int(11)", nullable: false),
                    subscriptionForEventId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_balancetopups", x => x.id);
                    table.ForeignKey(
                        name: "fk_BalanceTopups_Customer2",
                        column: x => x.cashierId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_BalanceTopups_Customer1",
                        column: x => x.Customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_BalanceTopups_Event1",
                        column: x => x.Event_id,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_BalanceTopups_Event2",
                        column: x => x.subscriptionForEventId,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eventsubscription",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Event_id = table.Column<int>(type: "int(11)", nullable: false),
                    Customer_id = table.Column<int>(type: "int(11)", nullable: false),
                    remainingCredit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventsubscription", x => new { x.id, x.Event_id, x.Customer_id });
                    table.ForeignKey(
                        name: "fk_EventSubscription_Customer1",
                        column: x => x.Customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_EventSubscription_Event1",
                        column: x => x.Event_id,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    amtPayedFromCredit = table.Column<float>(nullable: false),
                    amtPayedFromSubscriptionFee = table.Column<float>(nullable: false),
                    Cashier_id = table.Column<int>(type: "int(11)", nullable: false),
                    Customer_id = table.Column<int>(type: "int(11)", nullable: false),
                    Production_id = table.Column<int>(type: "int(11)", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_Order_Customer2",
                        column: x => x.Cashier_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Order_Customer1",
                        column: x => x.Customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Order_Production",
                        column: x => x.Production_id,
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderline",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int(11)", nullable: false),
                    Product_id = table.Column<int>(type: "int(11)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderline", x => x.Order_id);
                    table.ForeignKey(
                        name: "fk_OrderLine_Order1",
                        column: x => x.Order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_OrderLine_Product1",
                        column: x => x.Product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rollback",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int(11)", nullable: false),
                    Customer_id = table.Column<int>(type: "int(11)", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rollback", x => x.Order_id);
                    table.ForeignKey(
                        name: "fk_Rollback_Customer1",
                        column: x => x.Customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Rollback_Order1",
                        column: x => x.Order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_BalanceTopups_Customer2_idx",
                table: "balancetopups",
                column: "cashierId");

            migrationBuilder.CreateIndex(
                name: "fk_BalanceTopups_Customer1_idx",
                table: "balancetopups",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "fk_BalanceTopups_Event1_idx",
                table: "balancetopups",
                column: "Event_id");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "balancetopups",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_BalanceTopups_Event2_idx",
                table: "balancetopups",
                column: "subscriptionForEventId");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "customer",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "event",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_EventSubscription_Customer1_idx",
                table: "eventsubscription",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "fk_EventSubscription_Event1_idx",
                table: "eventsubscription",
                column: "Event_id");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "eventsubscription",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Order_Customer2_idx",
                table: "order",
                column: "Cashier_id");

            migrationBuilder.CreateIndex(
                name: "fk_Order_Customer1_idx",
                table: "order",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "fk_Order_Production_idx",
                table: "order",
                column: "Production_id");

            migrationBuilder.CreateIndex(
                name: "fk_OrderLine_Order1_idx",
                table: "orderline",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "fk_OrderLine_Product1_idx",
                table: "orderline",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "product",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "production",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Rollback_Customer1_idx",
                table: "rollback",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "fk_Rollback_Order1_idx",
                table: "rollback",
                column: "Order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "balancetopups");

            migrationBuilder.DropTable(
                name: "eventsubscription");

            migrationBuilder.DropTable(
                name: "orderline");

            migrationBuilder.DropTable(
                name: "rollback");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "production");
        }
    }
}
