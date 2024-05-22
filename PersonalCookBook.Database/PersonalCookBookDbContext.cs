using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PersonalCookBook.Database
{
    public class PersonalCookBookDbContext : DbContext
    {
        public PersonalCookBookDbContext(DbContextOptions<PersonalCookBookDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
