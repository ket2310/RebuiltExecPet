using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.Models;
using System.Reflection;
using System;
using RebuiltExecPetAPI.Enums;

namespace RebuiltExecPetAPI.DataContexts
{
    public class QuoteContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=roadrunner2\\sqlexpress;Initial Catalog=ExecPetTravel;Integrated Security=True");
        }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PetOwner>().HasData(new PetOwner
            {
                PetOwnerId = 1,
                FirstName = "Kirk",
                LastName = "Thomas",
                Email = "dablumaroon@gmail.com",
                PhoneNumber = "1234567890",
                CellNumber = "1234567890",
            });

            modelBuilder.Entity<Quote>().HasData(new Quote
            {
                QuoteId = 1,
                petOwnerId = 1,
                TravelType = TravelTypes.Oneway
            });


        }
    }
}
