﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.DataContexts;
using RebuiltExecPetAPI.MapModels;
using RebuiltExecPetAPI.Models;
using RebuiltExecPetAPI.Repositories;

namespace RebuiltExecPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryQuotesController : ControllerBase
    {
        private readonly IInMemoryQuoteRepository _inMemoryQuoteRepository;


        public InMemoryQuotesController(IInMemoryQuoteRepository inMemoryQuoteRepository)
        {
            _inMemoryQuoteRepository = inMemoryQuoteRepository;
        }
        // GET: api/InMemoryQuotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return Ok(await _inMemoryQuoteRepository.GetQuotes());
        }

        // GET: api/InMemoryQuotes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Quote>> GetQuote(int id)
        //{
        //    var quote = await _context.Quotes.FindAsync(id);

        //    if (quote == null)
        //    {
        //        return NotFound();
        //    }

        //    return quote;
        //}

        // PUT: api/InMemoryQuotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return BadRequest();
            }

            try
            {
                await _inMemoryQuoteRepository.UpdateQuote(quote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InMemoryQuotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteMap quote)
        {
            return Ok(await _inMemoryQuoteRepository.CreateAQuote(quote));
        }

        // DELETE: api/InMemoryQuotes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuote(int id)
        //{
        //    var quote = await _context.Quotes.FindAsync(id);
        //    if (quote == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Quotes.Remove(quote);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool QuoteExists(int id)
        {
            return _inMemoryQuoteRepository.DoesItLive(id);
        }
    }
}