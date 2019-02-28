using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DijleZonenApi.dijlezonen
{
    public partial class _1718_SPRINGDBContext : DbContext
    {
        public virtual DbSet<Balancetopup> Balancetopup { get; set; }
        public virtual DbSet<Closeout> Closeout { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Eventsubscription> Eventsubscription { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderline> Orderline { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rollback> Rollback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=dt5.ehb.be;port=3306;user=1718.SPRINGDB;password=N6xzNaZ;database=1718.SPRINGDB");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balancetopup>(entity =>
            {
                entity.ToTable("balancetopup");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_balancetopup_customer2_idx");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_balancetopup_customer1_idx");

                entity.HasIndex(e => e.EventId)
                    .HasName("fk_balancetopup_event1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CashierId)
                    .HasColumnName("cashier_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LocalId)
                    .HasColumnName("localId")
                    .HasMaxLength(90);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.BalancetopupCashier)
                    .HasForeignKey(d => d.CashierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balancetopup_customer2");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BalancetopupCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balancetopup_customer1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Balancetopup)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("fk_balancetopup_event1");
            });

            modelBuilder.Entity<Closeout>(entity =>
            {
                entity.ToTable("closeout");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_closeout_customer1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashierId)
                    .HasColumnName("cashierId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountedCash).HasColumnName("countedCash");

                entity.Property(e => e.ExpectedCash).HasColumnName("expectedCash");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.Closeout)
                    .HasForeignKey(d => d.CashierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_closeout_customer1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreditBalance).HasColumnName("creditBalance");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(90);

                entity.Property(e => e.HashedPass)
                    .HasColumnName("hashedPass")
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(90);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(45);

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(45);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(135);

                entity.Property(e => e.SubscriptionFee).HasColumnName("subscriptionFee");

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Eventsubscription>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.EventId });

                entity.ToTable("eventsubscription");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_EventSubscription_Customer1_idx");

                entity.HasIndex(e => e.EventId)
                    .HasName("fk_eventsubscription_event1_idx");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemainingCredit).HasColumnName("remainingCredit");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Eventsubscription)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EventSubscription_Customer1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Eventsubscription)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventsubscription_event1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_Order_Customer2_idx");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_Order_Customer1_idx");

                entity.HasIndex(e => e.EventId)
                    .HasName("fk_order_event1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AmtPayedFromCredit).HasColumnName("amtPayedFromCredit");

                entity.Property(e => e.AmtPayedFromSubscriptionFee).HasColumnName("amtPayedFromSubscriptionFee");

                entity.Property(e => e.CashierId)
                    .HasColumnName("Cashier_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LocalId)
                    .HasColumnName("localId")
                    .HasMaxLength(90);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("timeStamp")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.OrderCashier)
                    .HasForeignKey(d => d.CashierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Customer2");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order_Customer1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_event1");
            });

            modelBuilder.Entity<Orderline>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId });

                entity.ToTable("orderline");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_orderline_order1_idx");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fk_OrderLine_Product1_idx");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_orderline_order1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CriticalStock)
                    .HasColumnName("criticalStock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageUrl")
                    .HasMaxLength(135);

                entity.Property(e => e.InStock)
                    .HasColumnName("inStock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(90);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Rollback>(entity =>
            {
                entity.ToTable("rollback");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_Rollback_Customer1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_Rollback_Order1_idx");

                entity.HasIndex(e => e.TopupId)
                    .HasName("fk_rollback_balancetopup1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashierId)
                    .HasColumnName("cashier_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("timeStamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.TopupId)
                    .HasColumnName("topup_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.Rollback)
                    .HasForeignKey(d => d.CashierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rollback_Customer1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Rollback)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_Rollback_Order1");

                entity.HasOne(d => d.Topup)
                    .WithMany(p => p.Rollback)
                    .HasForeignKey(d => d.TopupId)
                    .HasConstraintName("fk_rollback_balancetopup1");
            });
        }
    }
}
