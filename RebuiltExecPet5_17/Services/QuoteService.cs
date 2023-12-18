using RebuiltExecPet5_17.Pages;
using RebuiltExecPetAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RebuiltExecPet5_17.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "api/quotes";

        

        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            var result =  await _httpClient.GetFromJsonAsync<Quote[]>(url);
            return result;
        }
    }
}
