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
            optionsBuilder.UseSqlServer("Data Source=coyote2\\sqlexpress;Initial Catalog=ExecPetTravel;Integrated Security=True");
        }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee Table
            modelBuilder.Entity<Quote>().HasData(new Quote
            {
                QuoteId = 1,
                FirstName = "Kirk",
                LastName = "Thomas",
                Email = "dablumaroon@gmail.com",
                PhoneNumber = "1234567890",
                CellNumber = "1234567890",
                Instructions = " Drive safe",
                TravelType = TravelTypes.Oneway
            });


        }
    }
}
