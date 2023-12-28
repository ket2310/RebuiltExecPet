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
    [Migration("20231226155557_CatsAndDogsFKs")]
    partial class CatsAndDogsFKs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("RebuiltExecPetAPI.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");
                });

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

                    b.Property<int>("catId")
                        .HasColumnType("int");

                    b.Property<int>("dogId")
                        .HasColumnType("int");

                    b.HasKey("PetOwnerId");

                    b.HasIndex("catId");

                    b.HasIndex("dogId");

                    b.ToTable("PetOwners");

                    b.HasData(
                        new
                        {
                            PetOwnerId = 1,
                            CellNumber = "1234567890",
                            Email = "dablumaroon@gmail.com",
                            FirstName = "Kirk",
                            LastName = "Thomas",
                            PhoneNumber = "1234567890",
                            catId = 0,
                            dogId = 0
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

            modelBuilder.Entity("RebuiltExecPetAPI.Models.PetOwner", b =>
                {
                    b.HasOne("RebuiltExecPetAPI.Models.Cat", "cat")
                        .WithMany()
                        .HasForeignKey("catId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RebuiltExecPetAPI.Models.Dog", "dog")
                        .WithMany()
                        .HasForeignKey("dogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cat");

                    b.Navigation("dog");
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
