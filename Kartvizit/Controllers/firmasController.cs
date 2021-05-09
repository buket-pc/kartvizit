using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kartvizit.Data;
using Kartvizit.Models;

namespace Kartvizit.Controllers
{
    public class firmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public firmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: firmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.firma.ToListAsync());
        }

        // GET: firmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.firma
                .FirstOrDefaultAsync(m => m.firmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // GET: firmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: firmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("firmaId,name,shortDesc,phone,address")] firma firma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firma);
        }

        // GET: firmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.firma.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return View(firma);
        }

        // POST: firmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("firmaId,name,shortDesc,phone,address")] firma firma)
        {
            if (id != firma.firmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!firmaExists(firma.firmaId))
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
            return View(firma);
        }

        // GET: firmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.firma
                .FirstOrDefaultAsync(m => m.firmaId == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: firmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.firma.FindAsync(id);
            _context.firma.Remove(firma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool firmaExists(int id)
        {
            return _context.firma.Any(e => e.firmaId == id);
        }
    }
}
