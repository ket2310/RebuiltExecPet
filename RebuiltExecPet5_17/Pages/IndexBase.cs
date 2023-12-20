using Microsoft.AspNetCore.Components;
using RebuiltExecPet5_17.Services;
using RebuiltExecPetAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebuiltExecPet5_17.Pages
{
    public class IndexBase :ComponentBase
    {
        [Inject]
        public IQuoteService QuoteService { get; set; }

        // Instantiate all objects
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        protected override async Task OnInitializedAsync()
        {
            Quotes = (await QuoteService.GetQuotes());

        }
    }
}
