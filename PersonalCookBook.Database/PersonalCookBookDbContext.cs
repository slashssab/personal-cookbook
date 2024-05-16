using Microsoft.EntityFrameworkCore;

namespace PersonalCookBook.Database
{
    public class PersonalCookBookDbContext : DbContext
    {
        public PersonalCookBookDbContext(DbContextOptions<PersonalCookBookDbContext> options) : base(options)
        {

        }
    }
}
