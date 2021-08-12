using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuoteAPI.DAL;

namespace QuoteAPI.Repository
{
    public interface IQuoteRepo : IRepository<Quote>
    {

    }

    public class QuoteRepo : Repository<Quote>, IQuoteRepo
    {
        public QuoteRepo(DbContext context) : base(context)
        {

        }
    }
}