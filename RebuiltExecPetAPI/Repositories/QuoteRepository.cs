using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.DataContexts;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<Quote> CreateAQuote(Quote Quote)
        {
            var result = await _context.Quotes.AddAsync(Quote);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Quote> GetQuote(int QuoteId)
        {
            return await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == QuoteId);
        }

        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var quotes = await _context.Quotes.ToListAsync();
            
            foreach (var item in quotes)
            {
                var po = new PetOwner();
                if (item.petOwnerId != 0 && item.petOwnerId != 0)
                    po = await _context.PetOwners.FirstOrDefaultAsync(p => p.PetOwnerId == item.petOwnerId);

                if (item.petOwnerId != 0)
                {
                    if (po != null)
                        item.petOwner.FirstName = po.FirstName.Trim();
                    item.petOwner.LastName = po.LastName.Trim();
                }
            }

            return quotes;
        }



        public async Task<Quote> UpdateQuote(Quote Quote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == Quote.QuoteId);

            if (result != null)
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
            return null;
        }
    }
}
