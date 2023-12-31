﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RebuiltExecPetAPI.DataContexts;

namespace RebuiltExecPetAPI.Migrations
{
    [DbContext(typeof(QuoteContext))]
    [Migration("20231219135313_BringOwnerObject")]
    partial class BringOwnerObject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RebuiltExecPetAPI.Models.PetOwner", b =>
                {
                    b.Property<int>("PetOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quoteId")
                        .HasColumnType("int");

                    b.HasKey("PetOwnerId");

                    b.HasIndex("quoteId")
                        .IsUnique();

                    b.ToTable("PetOwner");
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TravelType")
                        .HasColumnType("int");

                    b.HasKey("QuoteId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.PetOwner", b =>
                {
                    b.HasOne("RebuiltExecPetAPI.Models.Quote", "quote")
                        .WithOne("petOwner")
                        .HasForeignKey("RebuiltExecPetAPI.Models.PetOwner", "quoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quote");
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Quote", b =>
                {
                    b.Navigation("petOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
