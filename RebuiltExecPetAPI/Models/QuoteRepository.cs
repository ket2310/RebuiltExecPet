using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.DataContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Models
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
            return await _context.Quotes.FirstOrDefaultAsync(q  => q.QuoteId == QuoteId);
        }

        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }



        public async Task<Quote> UpdateQuote(Quote Quote)
        {
            var result = await _context.Quotes.FirstOrDefaultAsync(q => q.QuoteId == Quote.QuoteId);

            if (result != null)
            {
                result.FirstName = Quote.FirstName;
                result.LastName = Quote.LastName;
                result.Email = Quote.Email;
                result.PhoneNumber = Quote.PhoneNumber;
                result.CellNumber = Quote.CellNumber;
                result.TravelType = Quote.TravelType;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
