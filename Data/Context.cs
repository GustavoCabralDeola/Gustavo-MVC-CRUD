
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

        public DbSet<Gustavo_MVC_CRUD.Models.Usuario> Usuarios { get; set; } = default!;
    }
}
