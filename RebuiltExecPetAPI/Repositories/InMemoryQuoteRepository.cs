using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using RebuiltExecPetAPI.DataContexts;
using RebuiltExecPetAPI.Enums;
using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Repositories
{
    public class InMemoryQuoteRepository : IInMemoryQuoteRepository
    {
        private readonly QuoteInMemoryContext _context;

        public InMemoryQuoteRepository(QuoteInMemoryContext context)
        {
            _context = context;
        }

        //-------------------------------------------------
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var quotes = await _context.Quotes.ToListAsync();

            foreach (var quote in quotes)
            {
                var owner = await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId == quote.petOwnerId);

                if (owner != null)
                {
                    quote.petOwner.FirstName = owner.FirstName;
                    quote.petOwner.LastName = owner.LastName;
                    quote.petOwner.Email = owner.Email;
                    quote.petOwner.PhoneNumber = owner.PhoneNumber;
                    quote.petOwner.CellNumber = owner.CellNumber;
                    quote.petOwner.Instructions = owner.Instructions;

                    var cat = await _context.Cats.FirstOrDefaultAsync(c => c.CatId == quote.petOwner.catId);
                    if (cat != null)
                    {
                        quote.petOwner.cat.Age = cat.Age;
                        quote.petOwner.cat.Quantity = cat.Quantity;
                        quote.petOwner.cat.Breed = cat.Breed;
                        quote.petOwner.cat.Weight = cat.Weight;
                    }

                    var dog = await _context.Dogs.FirstOrDefaultAsync(d => d.DogId == quote.petOwner.dogId);
                    if (dog !=null)
                    {
                        quote.petOwner.dog.Age = dog.Age;
                        quote.petOwner.dog.Quantity = dog.Quantity;
                        quote.petOwner.dog.Breed = dog.Breed;
                        quote.petOwner.dog.Weight = dog.Weight;
                    }
                    await _context.SaveChangesAsync();
                    return quotes;
                }
            }
            return quotes;
        }

        public async Task<Quote> CreateAQuote(QuoteMap obj)
        {

            /*  
         
            {
              "petOwner": {
                "petOwnerId": 1,
                "firstName": "Kirk",
                "lastName": "Thomas",
                "email": "dablumaroon@gmail.com",
                "phoneNumber": "1-444-555-6666",
                "cellNumber": "1=999-222-3333",
                "instructions": "Drive slowly"
              },
              "travelType": 2
            }
            
             */
            Quote q = new Quote();
            q.petOwner = new PetOwner();
            q.petOwner.PetOwnerId = 1;
            q.petOwner.FirstName = obj.petOwner.FirstName;
            q.petOwner.LastName = obj.petOwner.LastName;
            q.petOwner.Email = obj.petOwner.Email;
            q.petOwner.PhoneNumber = obj.petOwner.PhoneNumber;
            q.petOwner.CellNumber = obj.petOwner.CellNumber;
            q.petOwner.Instructions = obj.petOwner.Instructions;
            q.petOwner.cat = new Cat();
            q.petOwner.cat.Breed = obj.petOwner.cat.Breed;
            q.petOwner.cat.Quantity = obj.petOwner.cat.Quantity;
            q.petOwner.cat.Age  =  obj.petOwner.cat.Age;
            q.petOwner.cat.Weight  = obj.petOwner.cat.Weight;

            q.petOwner.dog = new Dog();
            q.petOwner.dog.Breed = obj.petOwner.dog.Breed;
            q.petOwner.dog.Quantity =   obj.petOwner.dog.Quantity;
            q.petOwner.dog.Age  = obj.petOwner.dog.Age;
            q.petOwner.dog.Weight = obj.petOwner.dog.Weight;
            q.TravelType = obj.TravelType;

            await _context.Quotes.AddAsync(q);
            await _context.SaveChangesAsync();

            return q;
        }

        public async Task<Quote> UpdateQuote(Quote Quote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == Quote.QuoteId);

            if (result != null)
            {
                
                if (await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId ==
                 result.petOwnerId) != null)
                {
                    result.petOwner.FirstName = Quote.petOwner.FirstName;
                    result.petOwner.LastName = Quote.petOwner.LastName;
                    result.petOwner.Email = Quote.petOwner.Email;
                    result.petOwner.PhoneNumber = Quote.petOwner.PhoneNumber;
                    result.petOwner.CellNumber = Quote.petOwner.CellNumber;
                    result.TravelType = Quote.TravelType;
                    result.petOwner.Instructions = Quote.petOwner.Instructions;
            
                    if(await _context.Cats.FirstOrDefaultAsync(c => c.CatId == result.petOwner.catId) != null)
                    {
                        result.petOwner.cat.Age = Quote.petOwner.cat.Age;
                        result.petOwner.cat.Quantity = Quote.petOwner.cat.Quantity;
                        result.petOwner.cat.Breed = Quote.petOwner.cat.Breed;
                        result.petOwner.cat.Weight = Quote.petOwner.cat.Weight;
                    }

                    if (await _context.Dogs.FirstOrDefaultAsync(c => c.DogId == result.petOwner.dogId) != null)
                    {
                        result.petOwner.dog.Age = Quote.petOwner.dog.Age;
                        result.petOwner.dog.Quantity = Quote.petOwner.dog.Quantity;
                        result.petOwner.dog.Breed = Quote.petOwner.dog.Breed;
                        result.petOwner.dog.Weight = Quote.petOwner.dog.Weight;
                    }
                    await _context.SaveChangesAsync();
                    return result;
                }
            }
            return null;
        }

        public bool DoesItLive(int id)
        {
            return _context.Quotes.Any(e => e.QuoteId == id);
        }
    }
}
