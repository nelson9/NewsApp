using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models;

namespace Data
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("NewsDbConnectionString")
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Direct mapping
            modelBuilder.Entity<Article>()
                .HasKey(x => x.Id)
                .HasMany(x => x.Comments);
        }
    }
}
