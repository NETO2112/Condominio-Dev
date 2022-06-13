using CondominioDev.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Core.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Habitante> Habitantes { get; set; }
    }
}