using RebuiltExecPetAPI.Enums;
using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Repositories
{
    public interface IInMemoryQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
        bool DoesItLive(int id);
        Task<Quote> CreateAQuote(QuoteMap obj);
        Task<Quote> UpdateQuote(Quote Quote);
    }
}
