using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using word_html_utility.Models;

namespace word_html_utility.Controllers
{
    public class TemplateVersionsController : Controller
    {
        //ease is a greater threat to progress then hardship
        private readonly wordversionsContext _context;
        [Obsolete]
        private readonly IHostingEnvironment _environment;

        [Obsolete]
        public TemplateVersionsController(wordversionsContext context, IHostingEnvironment Hostingenvironment)
        {
            _context = context;
            _environment = Hostingenvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TemplateVersion.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templateVersion = await _context.TemplateVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (templateVersion == null)
            {
                return NotFound();
            }

            return View(templateVersion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create([Bind("Id,FunctionName,FunctionExample,AlternateExample,ImagePath,FunctionDescription,ExampleExaplanation,AlternateExamplesExplanation,TableOfContentHeading")] TemplateVersion templateVersion)
        {
            try
            {

                var file = Request.Form.Files[0];
                var folder = Path.Combine(_environment.WebRootPath, "images/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var filePaths = new List<string>();

                if (file.Length > 0)
                {
                    var filePath = Path.GetFileName(file.FileName);
                    filePaths.Add(filePath);
                    string fullpath = Path.Combine(folder, filePath);

                    string relaticePath = "~/images/" + '/' + filePath;

                    using (var stream = new FileStream(Path.Combine(folder, filePath), FileMode.Create))
                    {
                        file.CopyTo(stream);
                        templateVersion.ImagePath = relaticePath;
                    }
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                if (ModelState.IsValid)
                {
                    if (_context.TemplateVersion.Any(x=>x.FunctionName == templateVersion.FunctionName) || _context.TemplateVersion.Any(x => x.FunctionDescription == templateVersion.FunctionDescription))
                    {

                    }
                    else
                    {
                        _context.Add(templateVersion);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
            // return View(templateVersion);
        }

        public IActionResult RenderTemplate()
        {
            var tuple = new Tuple<IEnumerable<TemplateVersion>, IEnumerable<Tableofcontent>>(_context.TemplateVersion.ToList(), _context.Tableofcontent.ToList());
            return View(tuple);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templateVersion = await _context.TemplateVersion.FindAsync(id);
            if (templateVersion == null)
            {
                return NotFound();
            }
            return View(templateVersion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FunctionName,FunctionExample,AlternateExample,ImagePath,FunctionDescription,ExampleExaplanation,AlternateExamplesExplanation,TableOfContentHeading")] TemplateVersion templateVersion)
        {
            if (id != templateVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(templateVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemplateVersionExists(templateVersion.Id))
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
            return View(templateVersion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templateVersion = await _context.TemplateVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (templateVersion == null)
            {
                return NotFound();
            }

            return View(templateVersion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var templateVersion = await _context.TemplateVersion.FindAsync(id);
            _context.TemplateVersion.Remove(templateVersion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemplateVersionExists(int id)
        {
            return _context.TemplateVersion.Any(e => e.Id == id);
        }
    }
}
