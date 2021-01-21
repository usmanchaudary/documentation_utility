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
    public class TableofcontentsController : Controller
    {
        private readonly wordversionsContext _context;

        public TableofcontentsController(wordversionsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var wordversionsContext = _context.Tableofcontent.Include(t => t.Template);
            return View(await wordversionsContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableofcontent = await _context.Tableofcontent
                .Include(t => t.Template)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableofcontent == null)
            {
                return NotFound();
            }

            return View(tableofcontent);
        }

        public IActionResult Create()
        {
            ViewData["Templateid"] = new SelectList(_context.TemplateVersion, "Id", "FunctionName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,Templateid")] Tableofcontent tableofcontent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableofcontent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Templateid"] = new SelectList(_context.TemplateVersion, "Id", "Name", tableofcontent.Templateid);
            return View(tableofcontent);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableofcontent = await _context.Tableofcontent.FindAsync(id);
            if (tableofcontent == null)
            {
                return NotFound();
            }
            ViewData["Templateid"] = new SelectList(_context.TemplateVersion, "Id", "FunctionName", tableofcontent.Templateid);
            return View(tableofcontent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Heading,Templateid")] Tableofcontent tableofcontent)
        {
            if (id != tableofcontent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableofcontent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableofcontentExists(tableofcontent.Id))
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
            ViewData["Templateid"] = new SelectList(_context.TemplateVersion, "Id", "FunctionName", tableofcontent.Templateid);
            return View(tableofcontent);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableofcontent = await _context.Tableofcontent
                .Include(t => t.Template)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableofcontent == null)
            {
                return NotFound();
            }

            return View(tableofcontent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableofcontent = await _context.Tableofcontent.FindAsync(id);
            _context.Tableofcontent.Remove(tableofcontent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableofcontentExists(int id)
        {
            return _context.Tableofcontent.Any(e => e.Id == id);
        }
    }
}
