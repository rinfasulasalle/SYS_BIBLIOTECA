using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYS_BIBLIOTECA.Models;

namespace SYS_BIBLIOTECA.Controllers
{
    public class PublicacionesController : Controller
    {
        private readonly BibliotecaUniversitariaContext _context;

        public PublicacionesController(BibliotecaUniversitariaContext context)
        {
            _context = context;
        }

        // GET: Publicaciones
        public async Task<IActionResult> Index()
        {
            var bibliotecaUniversitariaContext = _context.Publicaciones.Include(p => p.IdUsuarioNavigation);
            return View(await bibliotecaUniversitariaContext.ToListAsync());
        }

        // GET: Publicaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacione == null)
            {
                return NotFound();
            }

            return View(publicacione);
        }

        // GET: Publicaciones/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,Titulo,Contenido,Imagen")] Publicacione publicacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", publicacione.IdUsuario);
            return View(publicacione);
        }

        // GET: Publicaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones.FindAsync(id);
            if (publicacione == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", publicacione.IdUsuario);
            return View(publicacione);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,Titulo,Contenido,Imagen")] Publicacione publicacione)
        {
            if (id != publicacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacioneExists(publicacione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", publicacione.IdUsuario);
            return View(publicacione);
        }

        // GET: Publicaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacione = await _context.Publicaciones
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicacione == null)
            {
                return NotFound();
            }

            return View(publicacione);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacione = await _context.Publicaciones.FindAsync(id);
            if (publicacione != null)
            {
                _context.Publicaciones.Remove(publicacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacioneExists(int id)
        {
            return _context.Publicaciones.Any(e => e.Id == id);
        }
    }
    [Route("api/Publicaciones")]
    [ApiController]
    public class PublicacionesAPIController : ControllerBase
    {
        private readonly BibliotecaUniversitariaContext _context;

        public PublicacionesAPIController(BibliotecaUniversitariaContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacione>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }

        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacione>> GetPublicacion(int id)
        {
            var publicacione = await _context.Publicaciones.FindAsync(id);

            if (publicacione == null)
            {
                return NotFound();
            }

            return publicacione;
        }

        // POST: api/Publicaciones
        [HttpPost]
        public async Task<ActionResult<Publicacione>> PostPublicacion(Publicacione publicacione)
        {
            _context.Publicaciones.Add(publicacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacione.Id }, publicacione);
        }

        private bool PublicacioneExists(int id)
        {
            return _context.Publicaciones.Any(e => e.Id == id);
        }
    }
}
