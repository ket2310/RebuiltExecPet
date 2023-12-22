using RebuiltExecPetAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebuiltExecPet5_17.Services
{
    public interface IQuoteService
    {
        Task<IEnumerable<Quote>> GetQuotes();
        Task<Quote> GetQuote();

        Task<Quote> UpdateQuote(Quote updatedQuote);
    }
}
