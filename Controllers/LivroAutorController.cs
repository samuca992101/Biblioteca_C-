using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaC_.Data;
using BibliotecaC_.Models;

namespace BibliotecaC_.Controllers
{
    public class LivroAutorController : Controller
    {
        private readonly BibliotecaC_Context _context;

        public LivroAutorController(BibliotecaC_Context context)
        {
            _context = context;
        }

        // GET: LivroAutor
        public async Task<IActionResult> Index()
        {
            var bibliotecaC_Context = _context.LivroAutor.Include(l => l.Autor).Include(l => l.Livro);
            return View(await bibliotecaC_Context.ToListAsync());
        }

        // GET: LivroAutor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LivroAutor == null)
            {
                return NotFound();
            }

            var livroAutor = await _context.LivroAutor
                .Include(l => l.Autor)
                .Include(l => l.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroAutor == null)
            {
                return NotFound();
            }

            return View(livroAutor);
        }

        // GET: LivroAutor/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo");
            return View();
        }

        // POST: LivroAutor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivroId,AutorId")] LivroAutor livroAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livroAutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livroAutor.AutorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // GET: LivroAutor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LivroAutor == null)
            {
                return NotFound();
            }

            var livroAutor = await _context.LivroAutor.FindAsync(id);
            if (livroAutor == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livroAutor.AutorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // POST: LivroAutor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId,AutorId")] LivroAutor livroAutor)
        {
            if (id != livroAutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livroAutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroAutorExists(livroAutor.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Nome", livroAutor.AutorId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // GET: LivroAutor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LivroAutor == null)
            {
                return NotFound();
            }

            var livroAutor = await _context.LivroAutor
                .Include(l => l.Autor)
                .Include(l => l.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livroAutor == null)
            {
                return NotFound();
            }

            return View(livroAutor);
        }

        // POST: LivroAutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LivroAutor == null)
            {
                return Problem("Entity set 'BibliotecaC_Context.LivroAutor'  is null.");
            }
            var livroAutor = await _context.LivroAutor.FindAsync(id);
            if (livroAutor != null)
            {
                _context.LivroAutor.Remove(livroAutor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroAutorExists(int id)
        {
          return (_context.LivroAutor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
