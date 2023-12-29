using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.DataContexts;
using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuoteContext _context;

        public QuoteRepository(QuoteContext quoteContext)
        {
            _context = quoteContext;
        }

        //-------------------------------------------------
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var quotes = await _context.Quotes.ToListAsync();

            foreach (var quote in quotes)
            {
                var petResult = await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId == quote.petOwnerId);

                if (petResult != null)
                {
                    quote.petOwner.FirstName = petResult.FirstName;
                    quote.petOwner.LastName = petResult.LastName;
                    quote.petOwner.Email = petResult.Email;
                    quote.petOwner.PhoneNumber = petResult.PhoneNumber;
                    quote.petOwner.CellNumber = petResult.CellNumber;
                    quote.petOwner.Instructions = petResult.Instructions;

                    var catResult = await _context.Cats.FirstOrDefaultAsync(c => c.CatId == petResult.catId);

                    if (catResult != null)
                    {
                        quote.petOwner.cat.Quantity= catResult.Quantity;
                        quote.petOwner.cat.Breed= catResult.Breed;
                        quote.petOwner.cat.Age= catResult.Age;
                        quote.petOwner.cat.Weight= catResult.Weight;
                    }


                    var dogResult = await _context.Dogs.FirstOrDefaultAsync(d => d.DogId == petResult.dogId);

                    if (dogResult != null)
                    {
                        quote.petOwner.dog.Quantity = dogResult.Quantity;
                        quote.petOwner.dog.Breed = dogResult.Breed;
                        quote.petOwner.dog.Age = dogResult.Age;
                        quote.petOwner.dog.Weight = dogResult.Weight;
                    }

                }
            }
            return quotes;
        }

        public async Task<Quote> CreateAQuote(QuoteMap obj)
        {
            Quote q = new Quote();
            q.petOwner = new PetOwner();
            q.petOwner.PetOwnerId = 1;
            q.petOwner.FirstName = obj.petOwner.FirstName;
            q.petOwner.LastName = obj.petOwner.LastName;
            q.petOwner.Email = obj.petOwner.Email;
            q.petOwner.PhoneNumber = obj.petOwner.PhoneNumber;
            q.petOwner.CellNumber = obj.petOwner.CellNumber;
            q.petOwner.Instructions = obj.petOwner.Instructions;
            q.TravelType = obj.TravelType;

            q.petOwner.cat = new Cat();
            q.petOwner.cat.Quantity = obj.petOwner.cat.Quantity;
            q.petOwner.cat.Weight = obj.petOwner.cat.Weight;
            q.petOwner.cat.Breed = obj.petOwner.cat.Breed;
            q.petOwner.cat.Age  = obj.petOwner.cat.Age;

            q.petOwner.dog = new Dog();
            q.petOwner.dog.Quantity = obj.petOwner.dog.Quantity;
            q.petOwner.dog.Weight = obj.petOwner.dog.Weight;
            q.petOwner.dog.Breed = obj.petOwner.dog.Breed;
            q.petOwner.dog.Age = obj.petOwner.dog.Age;

            await _context.Quotes.AddAsync(q);
            await _context.SaveChangesAsync();

            return q;
        }

        public async Task<Quote> UpdateQuote(Quote Quote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == Quote.QuoteId);

            if (result != null)
            {
                var petResult = await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId ==
                 result.petOwnerId);

                if (petResult != null)
                {
                    result.petOwner.FirstName = Quote.petOwner.FirstName;
                    result.petOwner.LastName = Quote.petOwner.LastName;
                    result.petOwner.Email = Quote.petOwner.Email;
                    result.petOwner.PhoneNumber = Quote.petOwner.PhoneNumber;
                    result.petOwner.CellNumber = Quote.petOwner.CellNumber;
                    result.TravelType = Quote.TravelType;
                    result.petOwner.Instructions = Quote.petOwner.Instructions;

                    var catResult = await _context.Cats.FirstOrDefaultAsync(c => c.CatId == petResult.catId);

                    if (catResult != null)
                    {
                        Quote.petOwner.cat.Quantity = catResult.Quantity;
                        Quote.petOwner.cat.Breed = catResult.Breed;
                        Quote.petOwner.cat.Age = catResult.Age;
                        Quote.petOwner.cat.Weight = catResult.Weight;
                    }


                    var dogResult = await _context.Dogs.FirstOrDefaultAsync(c => c.DogId == petResult.dogId);

                    if (dogResult != null)
                    {
                        Quote.petOwner.dog.Quantity = dogResult.Quantity;
                        Quote.petOwner.dog.Breed = dogResult.Breed;
                        Quote.petOwner.dog.Age = dogResult.Age;
                        Quote.petOwner.dog.Weight = dogResult.Weight;
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
