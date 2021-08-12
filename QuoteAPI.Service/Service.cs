using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuoteAPI.DAL;
using QuoteAPI.Repository;

namespace QuoteAPI.Serv
{
    public class Service
    {
        private UnitofWork uow = new UnitofWork(new QuoteApplicationEntities());

        public bool QuoteExists(int id)
        {
            return uow.Quote.Get(id) != null;
        }

        public IEnumerable<Quote> GetQuote()
        {
            return uow.Quote.Get();
        }

        public Quote GetQuotebyID(int id)
        {
            return uow.Quote.Get(id);
        }

        public void PutQuote(Quote q)
        {
            uow.Quote.Put(q);
        }

        public void PostQuote(Quote q)
        {
            uow.Quote.Post(q);
        }

        public Quote DeleteQuote(int id)
        {
            return uow.Quote.Delete(id);
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}