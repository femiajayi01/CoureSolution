using CoureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoureAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryDetail> CountryDetails { get; set; }


    }
}
