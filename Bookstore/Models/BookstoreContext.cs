using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models;

public partial class BookstoreContext : DbContext
{
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAuthor> TAuthors { get; set; }

    public virtual DbSet<TBook> TBooks { get; set; }

    public virtual DbSet<TCustomer> TCustomers { get; set; }

    public virtual DbSet<TOrder> TOrders { get; set; }

    public virtual DbSet<TOrderLine> TOrderLines { get; set; }

    public virtual DbSet<TPublisher> TPublishers { get; set; }

    public virtual DbSet<TSource> TSources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Datasource=Bookstore.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAuthor>(entity =>
        {
            entity.HasKey(e => e.FAuthorId);

            entity.ToTable("tAuthors");

            entity.Property(e => e.FAuthorId).HasColumnName("fAuthorID");
            entity.Property(e => e.FAuthorName).HasColumnName("fAuthorName");
        });

        modelBuilder.Entity<TBook>(entity =>
        {
            entity.HasKey(e => e.FIsbn);

            entity.ToTable("tBooks");

            entity.Property(e => e.FIsbn).HasColumnName("fISBN");
            entity.Property(e => e.FAuthorId).HasColumnName("fAuthorID");
            entity.Property(e => e.FBinding).HasColumnName("fBinding");
            entity.Property(e => e.FNumInStock).HasColumnName("fNumInStock");
            entity.Property(e => e.FPubId).HasColumnName("fPubID");
            entity.Property(e => e.FPubYear).HasColumnName("fPubYear");
            entity.Property(e => e.FRetailPrice)
                .HasColumnType("NUMERIC")
                .HasColumnName("fRetailPrice");
            entity.Property(e => e.FSourceId).HasColumnName("fSourceID");
            entity.Property(e => e.FTitle).HasColumnName("fTitle");

            entity.HasOne(d => d.FAuthor).WithMany(p => p.TBooks).HasForeignKey(d => d.FAuthorId);

            entity.HasOne(d => d.FPub).WithMany(p => p.TBooks).HasForeignKey(d => d.FPubId);

            entity.HasOne(d => d.FSource).WithMany(p => p.TBooks).HasForeignKey(d => d.FSourceId);
        });

        modelBuilder.Entity<TCustomer>(entity =>
        {
            entity.HasKey(e => e.FCustId);

            entity.ToTable("tCustomers");

            entity.Property(e => e.FCustId).HasColumnName("fCustID");
            entity.Property(e => e.FCustCity).HasColumnName("fCustCity");
            entity.Property(e => e.FCustEmail).HasColumnName("fCustEmail");
            entity.Property(e => e.FCustFirstName).HasColumnName("fCustFirstName");
            entity.Property(e => e.FCustLastName).HasColumnName("fCustLastName");
            entity.Property(e => e.FCustPhone).HasColumnName("fCustPhone");
            entity.Property(e => e.FCustState).HasColumnName("fCustState");
            entity.Property(e => e.FCustStreet).HasColumnName("fCustStreet");
            entity.Property(e => e.FCustZip).HasColumnName("fCustZip");
        });

        modelBuilder.Entity<TOrder>(entity =>
        {
            entity.HasKey(e => e.FOrderId);

            entity.ToTable("tOrders");

            entity.Property(e => e.FOrderId).HasColumnName("fOrderID");
            entity.Property(e => e.FCreditCardExpDate).HasColumnName("fCreditCardExpDate");
            entity.Property(e => e.FCreditCardNum).HasColumnName("fCreditCardNum");
            entity.Property(e => e.FCustId).HasColumnName("fCustID");
            entity.Property(e => e.FOrderDate).HasColumnName("fOrderDate");
            entity.Property(e => e.FOrderFilled).HasColumnName("fOrderFilled");

            entity.HasOne(d => d.FCust).WithMany(p => p.TOrders).HasForeignKey(d => d.FCustId);
        });

        modelBuilder.Entity<TOrderLine>(entity =>
        {
            entity.HasKey(e => new { e.FOrderId, e.FIsbn });

            entity.ToTable("tOrderLines");

            entity.Property(e => e.FOrderId).HasColumnName("fOrderID");
            entity.Property(e => e.FIsbn).HasColumnName("fISBN");
            entity.Property(e => e.FCostEach).HasColumnName("fCostEach");
            entity.Property(e => e.FQuantity).HasColumnName("fQuantity");
            entity.Property(e => e.FShipped).HasColumnName("fShipped");

            entity.HasOne(d => d.FIsbnNavigation).WithMany(p => p.TOrderLines).HasForeignKey(d => d.FIsbn);

            entity.HasOne(d => d.FOrder).WithMany(p => p.TOrderLines).HasForeignKey(d => d.FOrderId);
        });

        modelBuilder.Entity<TPublisher>(entity =>
        {
            entity.HasKey(e => e.FPubId);

            entity.ToTable("tPublishers");

            entity.Property(e => e.FPubId).HasColumnName("fPubID");
            entity.Property(e => e.FPubName).HasColumnName("fPubName");
        });

        modelBuilder.Entity<TSource>(entity =>
        {
            entity.HasKey(e => e.FSourceId);

            entity.ToTable("tSources");

            entity.Property(e => e.FSourceId).HasColumnName("fSourceID");
            entity.Property(e => e.FSourceCity).HasColumnName("fSourceCity");
            entity.Property(e => e.FSourceName).HasColumnName("fSourceName");
            entity.Property(e => e.FSourcePhone).HasColumnName("fSourcePhone");
            entity.Property(e => e.FSourceState).HasColumnName("fSourceState");
            entity.Property(e => e.FSourceStreet).HasColumnName("fSourceStreet");
            entity.Property(e => e.FSourceZip).HasColumnName("fSourceZip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
