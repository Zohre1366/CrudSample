using Application.Interfaces;
using Domain.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        public DbSet<Person> Person { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
            builder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}