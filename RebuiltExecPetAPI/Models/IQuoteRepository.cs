﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Models
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
        Task<Quote> GetQuote(int QuoteId);
        Task<Quote> CreateAQuote(Quote Quote);
        Task<Quote> UpdateQuote(Quote Quote);
    }
}
