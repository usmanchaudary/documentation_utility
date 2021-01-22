using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using word_html_utility.Models;

namespace word_html_utility.Controllers
{
    public class VersionsController : Controller
    {
        private readonly wordversionsContext _context;

        public VersionsController(wordversionsContext context)
        {
            _context = context;
        }

        // GET: Versions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Versions.ToListAsync());
        }

        // GET: Versions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versions = await _context.Versions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versions == null)
            {
                return NotFound();
            }

            return View(versions);
        }

        // GET: Versions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Versions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VersionNumber,VersionMessage,VersionDate")] Versions versions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(versions);
        }

        // GET: Versions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versions = await _context.Versions.FindAsync(id);
            if (versions == null)
            {
                return NotFound();
            }
            return View(versions);
        }

        // POST: Versions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VersionNumber,VersionMessage,VersionDate")] Versions versions)
        {
            if (id != versions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersionsExists(versions.Id))
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
            return View(versions);
        }

        // GET: Versions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versions = await _context.Versions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versions == null)
            {
                return NotFound();
            }

            return View(versions);
        }

        // POST: Versions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versions = await _context.Versions.FindAsync(id);
            _context.Versions.Remove(versions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersionsExists(int id)
        {
            return _context.Versions.Any(e => e.Id == id);
        }
    }
}
