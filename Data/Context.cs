using Gustavo_MVC_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Gustavo_MVC_CRUD.Data {
    public class Context : DbContext {

        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }

        public DbSet<User> Usuarios { get; set; }

    }
}
