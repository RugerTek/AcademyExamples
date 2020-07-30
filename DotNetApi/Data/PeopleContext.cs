using DotNetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Pet> Pet { get; set; }
    }
}