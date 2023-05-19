
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gustavo_MVC_CRUD.Data;
using Gustavo_MVC_CRUD.Models;

namespace Gustavo_MVC_CRUD.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return _context.Usuarios != null ?
                        View(await _context.Usuarios.ToListAsync()) :
                        Problem("Entity set 'Gustavo_MVC_CRUDContext.Usuario'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Empresa,Email,TelefonePessoal,TelefoneComercial")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel efetuar o cadastro, detalhes do erro: {erro.Message}";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Empresa,Email,TelefonePessoal,TelefoneComercial")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    TempData["MensagemSucesso"] = "Usuario editado com sucesso!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(usuario.Id))
                    {
                        TempData["MensagemErro"] = "Não foi possivel editar o cadastro";
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'Gustavo_MVC_CRUDContext.Usuario'  is null.");
            }
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario != null)
                {
                    TempData["MensagemSucesso"] = "Usuario deletado com sucesso!";
                    _context.Usuarios.Remove(usuario);
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel efetuar o cadastro";
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel efetuar o cadastro, detalhes do erro: {erro.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool UserExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

