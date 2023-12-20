﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RebuiltExecPetAPI.DataContexts;

namespace RebuiltExecPetAPI.Migrations
{
    [DbContext(typeof(QuoteContext))]
    partial class QuoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("PetOwnerId");

                    b.ToTable("PetOwners");

                    b.HasData(
                        new
                        {
                            PetOwnerId = 1,
                            CellNumber = "1234567890",
                            Email = "dablumaroon@gmail.com",
                            FirstName = "Kirk",
                            LastName = "Thomas",
                            PhoneNumber = "1234567890"
                        });
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TravelType")
                        .HasColumnType("int");

                    b.Property<int>("petOwnerId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId");

                    b.HasIndex("petOwnerId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            TravelType = 0,
                            petOwnerId = 1
                        });
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Quote", b =>
                {
                    b.HasOne("RebuiltExecPetAPI.Models.PetOwner", "petOwner")
                        .WithMany()
                        .HasForeignKey("petOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("petOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
