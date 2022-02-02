﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20220202082041_Mine2CraftMigration01")]
    partial class Mine2CraftMigration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.CompleteItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("Durability")
                        .HasColumnType("int")
                        .HasColumnName("durability");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("completeItem");
                });

            modelBuilder.Entity("Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("isCombustible")
                        .HasColumnType("tinyint");

                    b.Property<byte>("isCooked")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nickname");

                    b.Property<string>("Paswword")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pwd");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Entities.WorkbenchEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CurrentCompleteItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CurrentItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCompleteItemId");

                    b.HasIndex("CurrentItemId");

                    b.ToTable("Workbenchs");
                });

            modelBuilder.Entity("Entities.WorkbenchEntity", b =>
                {
                    b.HasOne("Entities.CompleteItemEntity", "CurrentCompleteItem")
                        .WithMany("Workbenches")
                        .HasForeignKey("CurrentCompleteItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ItemEntity", "CurrentItem")
                        .WithMany("Workbenches")
                        .HasForeignKey("CurrentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentCompleteItem");

                    b.Navigation("CurrentItem");
                });

            modelBuilder.Entity("Entities.CompleteItemEntity", b =>
                {
                    b.Navigation("Workbenches");
                });

            modelBuilder.Entity("Entities.ItemEntity", b =>
                {
                    b.Navigation("Workbenches");
                });
#pragma warning restore 612, 618
        }
    }
}