// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipmentTrackerAPI.Data;

namespace ShipmentTrackerAPI.Data.Migrations
{
    [DbContext(typeof(ShipmentTrackingDbContext))]
    partial class ShipmentTrackingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Characteristic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CheckpointId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ShipmentTrackingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("ShipmentTrackingId");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Checkpoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckPost")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("StateOrProvince")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Href")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Href")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferredType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.ShipmentTracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressFrom")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Carrier")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarrierTrackingUrl")
                        .HasColumnType("TEXT");

                    b.Property<long?>("CheckpointId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Href")
                        .HasColumnType("TEXT");

                    b.Property<long?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("RelatedCustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StatusChangeDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusChangeReason")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrackingCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TrackingDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("OrderId");

                    b.HasIndex("RelatedCustomerId");

                    b.ToTable("ShipmentTrackings");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Characteristic", b =>
                {
                    b.HasOne("ShipmentTrackerAPI.Models.Checkpoint", null)
                        .WithMany("Characteristics")
                        .HasForeignKey("CheckpointId");

                    b.HasOne("ShipmentTrackerAPI.Models.ShipmentTracking", null)
                        .WithMany("Characteristics")
                        .HasForeignKey("ShipmentTrackingId");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.ShipmentTracking", b =>
                {
                    b.HasOne("ShipmentTrackerAPI.Models.Checkpoint", "Checkpoint")
                        .WithMany()
                        .HasForeignKey("CheckpointId");

                    b.HasOne("ShipmentTrackerAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("ShipmentTrackerAPI.Models.Customer", "RelatedCustomer")
                        .WithMany()
                        .HasForeignKey("RelatedCustomerId");

                    b.Navigation("Checkpoint");

                    b.Navigation("Order");

                    b.Navigation("RelatedCustomer");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.Checkpoint", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("ShipmentTrackerAPI.Models.ShipmentTracking", b =>
                {
                    b.Navigation("Characteristics");
                });
#pragma warning restore 612, 618
        }
    }
}
