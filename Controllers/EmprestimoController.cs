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
    public class EmprestimoController : Controller
    {
        private readonly BibliotecaC_Context _context;

        public EmprestimoController(BibliotecaC_Context context)
        {
            _context = context;
        }

        // GET: Emprestimo
        public async Task<IActionResult> Index()
        {
            var bibliotecaC_Context = _context.Emprestimo?.Include(e => e.Funcionario).Include(e => e.Livro).Include(e => e.Usuario);
            return View(await bibliotecaC_Context.ToListAsync());
        }

        // GET: Emprestimo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Funcionario)
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimo/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome"); // Adicionando o SelectList para UsuarioId   
            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEmprestimo,DataDevolucao,LivroId,UsuarioId,FuncionarioId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Nome", emprestimo.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", emprestimo.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", emprestimo.UsuarioId); // Adicionando o SelectList para UsuarioId
            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                    .Include(e => e.Funcionario)
                    .Include(e => e.Livro)
                    .Include(e => e.Usuario)
                    .FirstOrDefaultAsync(e => e.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Nome", emprestimo.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", emprestimo.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", emprestimo.UsuarioId); // Adicionando o SelectList para UsuarioId
            return View(emprestimo);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEmprestimo,DataDevolucao,LivroId,UsuarioId,FuncionarioId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Nome", emprestimo.FuncionarioId);
            ViewData["LivroId"] = new SelectList(_context.Livro, "Id", "Titulo", emprestimo.LivroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", emprestimo.UsuarioId); // Adicionando o SelectList para UsuarioId
            return View(emprestimo);
        }

        // GET: Emprestimo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Funcionario)
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emprestimo == null)
            {
                return Problem("Entity set 'BibliotecaC_Context.Emprestimo'  is null.");
            }
            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimo.Remove(emprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
          return (_context.Emprestimo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
