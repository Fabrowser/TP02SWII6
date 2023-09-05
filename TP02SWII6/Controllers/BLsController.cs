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
    public class BLsController : Controller
    {
        private readonly AppDbContext _context;

        public BLsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BLs
        public async Task<IActionResult> Index()
        {
            return _context.Bls != null ?
                        View(await _context.Bls.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Bls'  is null.");
        }

        // GET: BLs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bL = await _context.Bls
                .FirstOrDefaultAsync(m => m.BLId == id);
            if (bL == null)
            {
                return NotFound();
            }

            return View(bL);
        }

        // GET: BLs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BLId,Numero,Consignee,Navio")] BL bL)
        {
            _context.Add(bL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BLs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bL = await _context.Bls.FindAsync(id);
            if (bL == null)
            {
                return NotFound();
            }
            return View(bL);
        }

        // POST: BLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BLId,Numero,Consignee,Navio")] BL bL)
        {
            if (id != bL.BLId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(bL);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return View(bL);
                }

        }

        // GET: BLs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bls == null)
            {
                return NotFound();
            }

            var bL = await _context.Bls
                .FirstOrDefaultAsync(m => m.BLId == id);
            if (bL == null)
            {
                return NotFound();
            }

            return View(bL);
        }

        // POST: BLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bls == null)
            {
                return Problem("Entity set 'AppDbContext.Bls'  is null.");
            }
            var bL = await _context.Bls.FindAsync(id);
            if (bL != null)
            {
                _context.Bls.Remove(bL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BLExists(int id)
        {
            return (_context.Bls?.Any(e => e.BLId == id)).GetValueOrDefault();
        }
    }
}
