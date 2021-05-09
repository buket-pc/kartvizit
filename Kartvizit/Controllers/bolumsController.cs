using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kartvizit.Data;
using Kartvizit.Models;
using Microsoft.AspNetCore.Authorization;

namespace Kartvizit.Controllers
{
    public class bolumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bolumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bolums
        public async Task<IActionResult> Index()
        {
            return View(await _context.bolum.ToListAsync());
        }
        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> AdminIndex()
        {
            return View(await _context.bolum.ToListAsync());
        }

        // GET: bolums/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.bolum
                .FirstOrDefaultAsync(m => m.bolumId == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // GET: bolums/Create
        [Authorize(Roles = "adminrole")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: bolums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> Create([Bind("bolumId,name,shortDesc,longDesc,orderId")] bolum bolum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolum);
        }

        // GET: bolums/Edit/5
        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.bolum.FindAsync(id);
            if (bolum == null)
            {
                return NotFound();
            }
            return View(bolum);
        }

        // POST: bolums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> Edit(int id, [Bind("bolumId,name,shortDesc,longDesc,orderId")] bolum bolum)
        {
            if (id != bolum.bolumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bolumExists(bolum.bolumId))
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
            return View(bolum);
        }

        // GET: bolums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.bolum
                .FirstOrDefaultAsync(m => m.bolumId == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // POST: bolums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolum = await _context.bolum.FindAsync(id);
            _context.bolum.Remove(bolum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bolumExists(int id)
        {
            return _context.bolum.Any(e => e.bolumId == id);
        }
    }
}
