
using Microsoft.EntityFrameworkCore;
using Gustavo_MVC_CRUD.Models;

namespace Gustavo_MVC_CRUD.Data
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
    }
}
