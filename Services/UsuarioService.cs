using Gustavo_MVC_CRUD.Data;
using Gustavo_MVC_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Gustavo_MVC_CRUD.Services
{
    public class UsuarioService
    {
        private readonly Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuarios.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<List<Usuario>> FindByName(string nome)
        {

        }
    }
}
