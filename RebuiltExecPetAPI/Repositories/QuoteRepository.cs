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
