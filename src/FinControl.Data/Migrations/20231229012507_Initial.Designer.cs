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
    [Migration("20231229012507_Initial")]
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
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("addedon");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifiedon");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

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
                        .HasColumnType("timestamp without time zone")
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
                        .HasColumnType("timestamp without time zone")
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
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("removedon");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_categories_accountid");

                    b.HasIndex("AddedBy")
                        .HasDatabaseName("ix_categories_addedby");

                    b.HasIndex("AddedOn")
                        .HasDatabaseName("ix_categories_addedon");

                    b.HasIndex("IsActive")
                        .HasDatabaseName("ix_categories_isactive");

                    b.HasIndex("RemovedOn")
                        .HasDatabaseName("ix_categories_removedon");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_categories_userid");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.Recurrence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("addedby");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("addedon");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer")
                        .HasColumnName("frequency");

                    b.Property<int>("Installment")
                        .HasColumnType("integer")
                        .HasColumnName("installment");

                    b.HasKey("Id")
                        .HasName("pk_recurrences");

                    b.ToTable("recurrences", (string)null);
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
                        .HasColumnType("timestamp without time zone")
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

                    b.Property<int>("Installment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("installment");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifiedon");

                    b.Property<Guid?>("RecurrenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("recurrenceid");

                    b.Property<Guid?>("RemovedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("removedby");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("removedon");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_transactions");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_transactions_accountid");

                    b.HasIndex("AddedBy")
                        .HasDatabaseName("ix_transactions_addedby");

                    b.HasIndex("AddedOn")
                        .HasDatabaseName("ix_transactions_addedon");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_transactions_categoryid");

                    b.HasIndex("RecurrenceId")
                        .HasDatabaseName("ix_transactions_recurrenceid");

                    b.HasIndex("RemovedOn")
                        .HasDatabaseName("ix_transactions_removedon");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_transactions_userid");

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
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("addedon");

                    b.Property<bool?>("ConfirmedWhatsAppNumber")
                        .HasColumnType("boolean")
                        .HasColumnName("confirmedwhatsappnumber");

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
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifiedon");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("passwordhash");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<string>("WhatsAppNumber")
                        .HasColumnType("text")
                        .HasColumnName("whatsappnumber");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_users_accountid");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("FinControl.Business.Models.Category", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("fk_categories_accounts_accountid");

                    b.HasOne("FinControl.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_categories_users_userid");

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinControl.Business.Models.Transaction", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("fk_transactions_accounts_accountid");

                    b.HasOne("FinControl.Business.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("fk_transactions_categories_categoryid");

                    b.HasOne("FinControl.Business.Models.Recurrence", "Recurrence")
                        .WithMany("Transactions")
                        .HasForeignKey("RecurrenceId")
                        .HasConstraintName("fk_transactions_recurrence_recurrenceid");

                    b.HasOne("FinControl.Business.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_transactions_users_userid");

                    b.Navigation("Account");

                    b.Navigation("Category");

                    b.Navigation("Recurrence");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinControl.Business.Models.User", b =>
                {
                    b.HasOne("FinControl.Business.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("fk_users_accounts_accountid");

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

            modelBuilder.Entity("FinControl.Business.Models.Recurrence", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinControl.Business.Models.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}