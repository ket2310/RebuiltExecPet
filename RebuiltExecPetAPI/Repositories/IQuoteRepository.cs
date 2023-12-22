using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.Repositories
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotes();
        bool DoesItLive(int id);
        Task<Quote> CreateAQuote(QuoteMap obj);
        Task<Quote> UpdateQuote(Quote Quote);
    }
}
