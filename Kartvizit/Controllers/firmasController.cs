using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kartvizit.Data;
using kartvizit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace kartvizit.Controllers
{
    [Authorize]
    public class firmasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public firmasController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: firmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.firma.OrderByDescending(i => i.firmaId).ToListAsync());
        }

        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> AdminIndex(int id)
        {
            var kategori = _context.bolum.Where(i => i.bolumId == id).SingleOrDefault();

            ViewData["bolumid"] = id;
            ViewData["bolumAdi"] = kategori.name;


            return View(await _context.firma.Where(a=>a.firmaBolumId==id).OrderBy(a=>a.name).ToListAsync());
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

            int bolumId = firma.firmaBolumId;
            var kategori = _context.bolum.Where(i => i.bolumId == bolumId).SingleOrDefault();
            ViewData["bolumAdi"] = kategori.name;
            ViewData["bolumId"] = bolumId;

            return View(firma);
        }

        // GET: firmas/Create
        [Authorize(Roles = "adminrole")]
        public IActionResult Create(int id)
        {
            firma firma = new firma()
            {
                firmaBolumId = id
            };

            int bolumId = firma.firmaBolumId;
            var kategori = _context.bolum.Where(i => i.bolumId == bolumId).SingleOrDefault();
            ViewData["bolumAdi"] = kategori.name;
            ViewData["bolumId"] = bolumId;

            return View(firma);
        }

        // POST: firmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "adminrole")]
        public ActionResult Create(firma firma)
        {
            if (ModelState.IsValid)
            {
                if (firma.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(firma.ImageFile.FileName);
                    string extension = Path.GetExtension(firma.ImageFile.FileName);
                    firma.imageLink = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/firma/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        firma.ImageFile.CopyTo(fileStream);
                    }
                }

                firma.createDate = DateTime.Now;

                _context.Add(firma);
                _context.SaveChanges();
                return RedirectToAction("AdminIndex", "firmas", new { id = firma.firmaBolumId });
            }
            return View(firma);
        }

        // GET: firmas/Edit/5
        [Authorize(Roles = "adminrole")]
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

            int bolumId = firma.firmaBolumId;
            var kategori = _context.bolum.Where(i => i.bolumId == bolumId).SingleOrDefault();
            ViewData["bolumAdi"] = kategori.name;
            ViewData["bolumId"] = bolumId;

            return View(firma);
        }

        // POST: firmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "adminrole")]
        public ActionResult Edit(firma firma)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (firma.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(firma.ImageFile.FileName);
                        string extension = Path.GetExtension(firma.ImageFile.FileName);
                        firma.imageLink = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/images/firma/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            firma.ImageFile.CopyTo(fileStream);
                        }
                    }

                    _context.Update(firma);
                    _context.SaveChanges();
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
                return RedirectToAction("AdminIndex", "firmas", new { id = firma.firmaBolumId });
            }
            return View(firma);
        }

        // GET: firmas/Delete/5
        [Authorize(Roles = "adminrole")]
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

            int bolumId = firma.firmaBolumId;
            var kategori = _context.bolum.Where(i => i.bolumId == bolumId).SingleOrDefault();
            ViewData["bolumAdi"] = kategori.name;
            ViewData["bolumId"] = bolumId;


            return View(firma);
        }

        // POST: firmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "adminrole")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.firma.FindAsync(id);
            _context.firma.Remove(firma);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminIndex", "firmas", new { id = firma.firmaBolumId });
        }

        private bool firmaExists(int id)
        {
            return _context.firma.Any(e => e.firmaId == id);
        }
    }
}
