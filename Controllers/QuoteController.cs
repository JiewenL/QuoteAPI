using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QuoteAPI.CustomExceptionFilter;
using QuoteAPI.DAL;
using QuoteAPI.Serv;

namespace QuoteAPI.Controllers
{
    [Authorize]
    public class QuoteController : ApiController
    {
        private Service service = new Service();

        // GET: api/Quote
        public IEnumerable<Quote> GetQuotes()
        {
            return service.GetQuote();
        }

        // GET: api/Quote/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetQuote(int id)
        {
            if (!service.QuoteExists(id))
            {
                return NotFound();
            }

            return Ok(service.GetQuotebyID(id));
        }

        // PUT: api/Quote/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuote(int id, Quote quote)
        {
            if (quote==null||id!=quote.QuoteID)
            {
                return BadRequest();
            }

            service.PutQuote(quote);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Quote
        [ResponseType(typeof(Quote))]
        public IHttpActionResult PostQuote(Quote quote)
        {
            service.PostQuote(quote);
            return CreatedAtRoute("DefaultApi", new { id = quote.QuoteID }, quote);
        }

        // DELETE: api/Quote/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult DeleteQuote(int id)
        {
            return Ok(service.DeleteQuote(id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}