﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class GardeningContext : DbContext
{
    public GardeningContext()
    {
    }

    public GardeningContext(DbContextOptions<GardeningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Producttype> Producttypes { get; set; }

    public virtual DbSet<Refreshtoken> Refreshtokens { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Requestdetail> Requestdetails { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Viewclient> Viewclients { get; set; }

    public virtual DbSet<Vwestado> Vwestados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=gardening", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdEmployee, "idEmployee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasColumnName("creditLimit");
            entity.Property(e => e.Fax)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("fax");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.LastnameContact)
                .HasMaxLength(50)
                .HasColumnName("lastnameContact");
            entity.Property(e => e.NameClient)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nameClient");
            entity.Property(e => e.NameContact)
                .HasMaxLength(50)
                .HasColumnName("nameContact");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zipCode");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("client_ibfk_1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion)
                .IsRequired()
                .HasMaxLength(32);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdBoss, "idBoss");

            entity.HasIndex(e => e.IdOffice, "idOffice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Extension)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("extension");
            entity.Property(e => e.FirstSurname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("firstSurname");
            entity.Property(e => e.IdBoss).HasColumnName("idBoss");
            entity.Property(e => e.IdOffice).HasColumnName("idOffice");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.SecondSurname)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("secondSurname");

            entity.HasOne(d => d.IdBossNavigation).WithMany(p => p.InverseIdBossNavigation)
                .HasForeignKey(d => d.IdBoss)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.IdOfficeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdOffice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("office");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.OfficineCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("officineCode");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Region)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("zipCode");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.IdClient, "idClient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.Total)
                .HasPrecision(15, 2)
                .HasColumnName("total");
            entity.Property(e => e.TransactionId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("transactionId");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdProductType, "idProductType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(25)
                .HasColumnName("dimensions");
            entity.Property(e => e.IdProductType).HasColumnName("idProductType");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.ProductCode)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("productCode");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasColumnName("provider");
            entity.Property(e => e.ProviderPrice)
                .HasPrecision(15, 2)
                .HasColumnName("providerPrice");
            entity.Property(e => e.SalePrice)
                .HasPrecision(15, 2)
                .HasColumnName("salePrice");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<Producttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producttype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescriptionHtml)
                .HasColumnType("text")
                .HasColumnName("descriptionHtml");
            entity.Property(e => e.DescriptionText)
                .HasColumnType("text")
                .HasColumnName("descriptionText");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .HasColumnName("image");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Refreshtoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refreshtoken");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasMaxLength(6)
                .HasColumnName("created");
            entity.Property(e => e.Expires)
                .HasMaxLength(6)
                .HasColumnName("expires");
            entity.Property(e => e.Revoked)
                .HasMaxLength(6)
                .HasColumnName("revoked");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Refreshtokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("refreshtoken_ibfk_1");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("request");

            entity.HasIndex(e => e.IdClient, "idClient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeliveryDate).HasColumnName("deliveryDate");
            entity.Property(e => e.ExpectedDate).HasColumnName("expectedDate");
            entity.Property(e => e.Feedback)
                .HasColumnType("text")
                .HasColumnName("feedback");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.RequestDate).HasColumnName("requestDate");
            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("state");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("request_ibfk_1");
        });

        modelBuilder.Entity<Requestdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("requestdetail");

            entity.HasIndex(e => e.IdProduct, "idProduct");

            entity.HasIndex(e => e.IdRequest, "idRequest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdRequest).HasColumnName("idRequest");
            entity.Property(e => e.LineNumber).HasColumnName("lineNumber");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(15, 2)
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Requestdetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("requestdetail_ibfk_2");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.Requestdetails)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("requestdetail_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdenNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("idenNumber");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRol")
                        .HasConstraintName("userrol_ibfk_1"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .HasConstraintName("userrol_ibfk_2"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdRol")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("userrol");
                        j.HasIndex(new[] { "IdRol" }, "idRol");
                        j.IndexerProperty<int>("IdUser").HasColumnName("idUser");
                        j.IndexerProperty<int>("IdRol").HasColumnName("idRol");
                    });
        });

        modelBuilder.Entity<Viewclient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewclient");

            entity.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasColumnName("creditLimit");
            entity.Property(e => e.Fax)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("fax");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.LastnameContact)
                .HasMaxLength(50)
                .HasColumnName("lastnameContact");
            entity.Property(e => e.NameClient)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nameClient");
            entity.Property(e => e.NameContact)
                .HasMaxLength(50)
                .HasColumnName("nameContact");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zipCode");
        });

        modelBuilder.Entity<Vwestado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwestados");

            entity.Property(e => e.StateRequest)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("state_request");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
