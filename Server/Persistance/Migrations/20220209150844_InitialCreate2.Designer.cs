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
    [Migration("20220209150844_InitialCreate2")]
    partial class InitialCreate2
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
                        .HasColumnName("id");

                    b.Property<string>("CompleteItemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("complete_item_type");

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

                    b.ToTable("CompleteItems");

                    b.HasDiscriminator<string>("CompleteItemType").HasValue("CompleteItemEntity");
                });

            modelBuilder.Entity("Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnName("id");

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
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompleteItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompleteItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Workbenches");
                });

            modelBuilder.Entity("Entities.ArmorEntity", b =>
                {
                    b.HasBaseType("Entities.CompleteItemEntity");

                    b.Property<int>("ArmorPoint")
                        .HasColumnType("int")
                        .HasColumnName("armorPoint");

                    b.HasDiscriminator().HasValue("armors");
                });

            modelBuilder.Entity("Entities.ToolEntity", b =>
                {
                    b.HasBaseType("Entities.CompleteItemEntity");

                    b.Property<int>("AttackPoint")
                        .HasColumnType("int")
                        .HasColumnName("attackPoint");

                    b.HasDiscriminator().HasValue("tools");
                });

            modelBuilder.Entity("Entities.WorkbenchEntity", b =>
                {
                    b.HasOne("Entities.CompleteItemEntity", "CompleteItem")
                        .WithMany("Workbenches")
                        .HasForeignKey("CompleteItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ItemEntity", "Item")
                        .WithMany("Workbenches")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompleteItem");

                    b.Navigation("Item");
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
