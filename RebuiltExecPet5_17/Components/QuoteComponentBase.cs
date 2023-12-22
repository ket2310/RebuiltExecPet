using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RebuiltExecPetAPI.Models;
using AutoMapper;
using RebuiltExecPet5_17.Services;
using RebuiltExecPetAPI.MapModels;

namespace RebuiltExecPet5_17.Components
{
    public class QuoteComponentBase : ComponentBase
    {
        [Inject]
        public IQuoteService QuoteService { get; set; }
        public Quote Quote { get; set; } = new Quote { petOwner = new PetOwner() };
        public QuoteMap quoteMap { get; set; } = new QuoteMap { petOwner = new PetOwner() };

        [Parameter]
        public string Id { get; set; }
 
        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int QuoteId);

            if (QuoteId != 0)
            {
                Quote = await QuoteService.GetQuote(int.Parse(Id));
            }
            else
            {
                Quote = new Quote
                {
                   
                };
            }

            Mapper.Map(Quote, quoteMap);
        }
       
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(quoteMap, Quote);

            Quote result = null;

            if (Quote.QuoteId != 0)
            {
                result = await QuoteService.UpdateQuote(Quote);
            }
            else
            {
                result = await QuoteService.CreateQuote(Quote);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
