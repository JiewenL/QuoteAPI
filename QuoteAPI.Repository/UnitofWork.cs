using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuoteAPI.Repository
{
    public class UnitofWork : IDisposable
    {
        private DbContext Context;
        public IQuoteRepo Quote;

        public UnitofWork(DbContext context)
        {
            Context = context;
            Quote = new QuoteRepo(context);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}