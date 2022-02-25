﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompleteItemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durability")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompleteItems");

                    b.HasDiscriminator<string>("CompleteItemType").HasValue("CompleteItemEntity");
                });

            modelBuilder.Entity("Entities.FurnaceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemAfterCookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemBeforeCookingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemAfterCookingId")
                        .IsUnique();

                    b.HasIndex("ItemBeforeCookingId");

                    b.ToTable("Furnaces");
                });

            modelBuilder.Entity("Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsCombustible")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsCooked")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("armors");
                });

            modelBuilder.Entity("Entities.ToolEntity", b =>
                {
                    b.HasBaseType("Entities.CompleteItemEntity");

                    b.Property<int>("AttackPoint")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("tools");
                });

            modelBuilder.Entity("Entities.FurnaceEntity", b =>
                {
                    b.HasOne("Entities.ItemEntity", "ItemAfterCooking")
                        .WithOne("Furnace")
                        .HasForeignKey("Entities.FurnaceEntity", "ItemAfterCookingId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Entities.ItemEntity", "ItemBeforeCooking")
                        .WithMany()
                        .HasForeignKey("ItemBeforeCookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemAfterCooking");

                    b.Navigation("ItemBeforeCooking");
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
                    b.Navigation("Furnace");

                    b.Navigation("Workbenches");
                });
#pragma warning restore 612, 618
        }
    }
}
