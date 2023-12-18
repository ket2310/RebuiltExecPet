using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RebuiltExecPetAPI.DataContexts;
using RebuiltExecPetAPI.Models;

namespace RebuiltExecPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            try
            {
                return Ok(await _quoteRepository.GetQuotes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");

            }
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _quoteRepository.GetQuote(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateQuote(int id, Quote quote)
        {
            try
            {
                if (id != quote.QuoteId)
                    return BadRequest("Quote ID mismatch");

                var QuoteToUpdate = await  _quoteRepository.GetQuote(id);

                if (QuoteToUpdate == null)
                    return NotFound($"Quote with Id = {id} not found");

                return Ok(await _quoteRepository.UpdateQuote(quote));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // POST: api/Quotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        //{
        //    _context.Quotes.Add(quote);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetQuote", new { id = quote.QuoteId }, quote);
        //}

        //// DELETE: api/Quotes/5
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

        //private bool QuoteExists(int id)
        //{
        //    return _context.Quotes.Any(e => e.QuoteId == id);
        //}
    }
}
