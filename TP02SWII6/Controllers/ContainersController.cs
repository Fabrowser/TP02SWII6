using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02_SWII6.Data;
using TP02_SWII6.Models;

namespace TP02_SWII6.Controllers
{
    public class ContainersController : Controller
    {
        private readonly AppDbContext _context;

        public ContainersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Containers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Containers.Include(c => c.BL);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Containers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.ContainerId == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // GET: Containers/Create
        public IActionResult Create()
        {
            ViewData["BLId"] = new SelectList(_context.Bls, "BLId", "Numero");
            return View();
        }

        // POST: Containers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContainerId,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            try
            {
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
                return View(container);
            }
            ViewData["BLId"] = new SelectList(_context.Bls, "BLId", "BLId", container.BLId);
            return View(container);
        }

        // GET: Containers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            ViewData["BLId"] = new SelectList(_context.Bls, "BLId", "Numero", container.BLId);
            return View(container);
        }

        // POST: Containers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContainerId,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            if (id != container.ContainerId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
                return View(container);
            }

            ViewData["BLId"] = new SelectList(_context.Bls, "BLId", "BLId", container.BLId);

        }

        // GET: Containers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Containers == null)
            {
                return NotFound();
            }

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.ContainerId == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Containers == null)
            {
                return Problem("Entity set 'AppDbContext.Containers'  is null.");
            }
            var container = await _context.Containers.FindAsync(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerExists(int id)
        {
            return (_context.Containers?.Any(e => e.ContainerId == id)).GetValueOrDefault();
        }
    }
}
