using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.GenericRepo;
using NewsApp.Models;

namespace Data.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        
    }
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public NewsContext NewsContext
        {
            get
            {
                return Context as NewsContext;
            }
        }

        public ArticleRepository(NewsContext context) : base(context) { }
    }
}
