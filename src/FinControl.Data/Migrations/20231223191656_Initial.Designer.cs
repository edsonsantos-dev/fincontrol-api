﻿// <auto-generated />
using System;
using FinControl.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinControl.Data.Migrations
{
    [DbContext(typeof(FinControlContext))]
    [Migration("20231223191656_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinControl.Business.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("addedby");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("addedon");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedon");

                    b.Property<Guid?>("RemovedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("removedby");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("removedn");

                    b.HasKey("Id");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("accountid");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("addedby");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("addedon");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isactive");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<Guid?>("RemovedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("removedby");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("removedn");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AddedBy");

                    b.HasIndex("AddedOn");

                    b.HasIndex("IsActive");

                    b.HasIndex("RemovedOn");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("accountid");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("addedby");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("addedon");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("categoryid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedon");

                    b.Property<Guid?>("RemovedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("removedby");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("removedn");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AddedBy");

                    b.HasIndex("AddedOn");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RemovedOn");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("accountid");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("addedby");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("addedon");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("isactive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("lastname");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedon");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("passwordhash");

                    b.Property<Guid?>("RemovedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("removedby");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("removedn");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.Category", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FinControl.Business.Models.Transaction", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("FinControl.Business.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinControl.Business.Models.User", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FinControl.Business.Models.Account", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Transactions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FinControl.Business.Models.Category", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}