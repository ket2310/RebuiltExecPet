using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.DataContexts
{
    public class QuoteInMemoryContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase(databaseName: "ExecPetTravelInMemorydb");

        }


        public DbSet<Quote> Quotes { get; set; }

        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }

    }
}
