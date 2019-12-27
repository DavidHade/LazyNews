using LazyNews.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyNews.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DataContext()
            : base("NewsDBConnectionString")
        {

        }

        [DisplayName("NewsEntry")]
        public DbSet<NewsEntry> NewsEntry { get; set; }
    }
}
