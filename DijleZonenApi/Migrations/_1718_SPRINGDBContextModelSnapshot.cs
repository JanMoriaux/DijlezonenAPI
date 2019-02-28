﻿// <auto-generated />
using DijleZonenApi.dijlezonen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DijleZonenApi.Migrations
{
    [DbContext(typeof(_1718_SPRINGDBContext))]
    partial class _1718_SPRINGDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Balancetopups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<float>("Amount");

                    b.Property<int>("CashierId")
                        .HasColumnName("cashierId")
                        .HasColumnType("int(11)");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_id")
                        .HasColumnType("int(11)");

                    b.Property<int?>("EventId");

                    b.Property<int?>("EventId1");

                    b.Property<int?>("SubscriptionForEventCustomerId");

                    b.Property<int?>("SubscriptionForEventEventId");

                    b.Property<int>("SubscriptionForEventId")
                        .HasColumnName("subscriptionForEventId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("SubscriptionForEventId1");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("CashierId")
                        .HasName("fk_BalanceTopups_Customer2_idx");

                    b.HasIndex("CustomerId")
                        .HasName("fk_BalanceTopups_Customer1_idx");

                    b.HasIndex("EventId");

                    b.HasIndex("EventId1");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.HasIndex("SubscriptionForEventId")
                        .HasName("fk_BalanceTopups_Event2_idx");

                    b.HasIndex("SubscriptionForEventId1", "SubscriptionForEventEventId", "SubscriptionForEventCustomerId");

                    b.ToTable("balancetopups");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<float?>("CreditBalance")
                        .HasColumnName("creditBalance");

                    b.Property<string>("FirstName")
                        .HasColumnName("firstName")
                        .HasMaxLength(90);

                    b.Property<string>("HashedPass")
                        .HasColumnName("hashedPass")
                        .HasMaxLength(45);

                    b.Property<string>("LastName")
                        .HasColumnName("lastName")
                        .HasMaxLength(90);

                    b.Property<string>("Role")
                        .HasColumnName("role")
                        .HasMaxLength(45);

                    b.Property<string>("Salt")
                        .HasColumnName("salt")
                        .HasMaxLength(45);

                    b.Property<string>("UserName")
                        .HasColumnName("userName")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnName("fromDate")
                        .HasColumnType("datetime");

                    b.Property<float>("SubscriptionFee")
                        .HasColumnName("subscriptionFee");

                    b.Property<DateTime>("ToDate")
                        .HasColumnName("toDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.ToTable("event");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Eventsubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int>("EventId")
                        .HasColumnName("Event_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_id")
                        .HasColumnType("int(11)");

                    b.Property<float>("RemainingCredit")
                        .HasColumnName("remainingCredit");

                    b.HasKey("Id", "EventId", "CustomerId");

                    b.HasIndex("CustomerId")
                        .HasName("fk_EventSubscription_Customer1_idx");

                    b.HasIndex("EventId")
                        .HasName("fk_EventSubscription_Event1_idx");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.ToTable("eventsubscription");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<float>("AmtPayedFromCredit")
                        .HasColumnName("amtPayedFromCredit");

                    b.Property<float>("AmtPayedFromSubscriptionFee")
                        .HasColumnName("amtPayedFromSubscriptionFee");

                    b.Property<int>("CashierId")
                        .HasColumnName("Cashier_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("ProductionId")
                        .HasColumnName("Production_id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnName("timeStamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CashierId")
                        .HasName("fk_Order_Customer2_idx");

                    b.HasIndex("CustomerId")
                        .HasName("fk_Order_Customer1_idx");

                    b.HasIndex("ProductionId")
                        .HasName("fk_Order_Production_idx");

                    b.ToTable("order");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Orderline", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Order_id")
                        .HasColumnType("int(11)");

                    b.Property<int?>("OrderId1");

                    b.Property<int>("ProductId")
                        .HasColumnName("Product_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int(11)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderId")
                        .HasName("fk_OrderLine_Order1_idx");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId")
                        .HasName("fk_OrderLine_Product1_idx");

                    b.ToTable("orderline");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Product", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<int>("CriticalStock")
                        .HasColumnName("criticalStock")
                        .HasColumnType("int(11)");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("imageUrl")
                        .HasMaxLength(135);

                    b.Property<int>("InStock")
                        .HasColumnName("inStock")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(90);

                    b.Property<float>("Price")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.ToTable("product");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("id_UNIQUE");

                    b.ToTable("production");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Rollback", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("Order_id")
                        .HasColumnType("int(11)");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_id")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnName("timeStamp")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId")
                        .HasName("fk_Rollback_Customer1_idx");

                    b.HasIndex("OrderId")
                        .HasName("fk_Rollback_Order1_idx");

                    b.ToTable("rollback");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Balancetopups", b =>
                {
                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Cashier")
                        .WithMany()
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Event")
                        .WithMany("BalancetopupsEvent")
                        .HasForeignKey("EventId");

                    b.HasOne("DijleZonenApi.dijlezonen.Event")
                        .WithMany("BalancetopupsSubscriptionForEvent")
                        .HasForeignKey("EventId1");

                    b.HasOne("DijleZonenApi.dijlezonen.Eventsubscription", "SubscriptionForEvent")
                        .WithMany()
                        .HasForeignKey("SubscriptionForEventId1", "SubscriptionForEventEventId", "SubscriptionForEventCustomerId");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Eventsubscription", b =>
                {
                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Event", "Event")
                        .WithMany("Eventsubscription")
                        .HasForeignKey("EventId")
                        .HasConstraintName("fk_EventSubscription_Event1");
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Order", b =>
                {
                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Cashier")
                        .WithMany()
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Production", "Production")
                        .WithMany("Order")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Orderline", b =>
                {
                    b.HasOne("DijleZonenApi.dijlezonen.Order", "Order")
                        .WithMany("Orderline")
                        .HasForeignKey("OrderId1");

                    b.HasOne("DijleZonenApi.dijlezonen.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DijleZonenApi.dijlezonen.Rollback", b =>
                {
                    b.HasOne("DijleZonenApi.dijlezonen.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DijleZonenApi.dijlezonen.Order", "Order")
                        .WithOne("Rollback")
                        .HasForeignKey("DijleZonenApi.dijlezonen.Rollback", "OrderId")
                        .HasConstraintName("fk_Rollback_Order1");
                });
#pragma warning restore 612, 618
        }
    }
}
