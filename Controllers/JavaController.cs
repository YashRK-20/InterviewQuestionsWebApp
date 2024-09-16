using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewQuestions.Data;
using InterviewQuestions.Models;
using Microsoft.AspNetCore.Authorization;

namespace InterviewQuestions.Controllers
{
    public class JavaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JavaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Java
        public async Task<IActionResult> Index()
        {
            return View(await _context.Java.ToListAsync());
        }
        public async Task<IActionResult> Search()
        {
            return View();
        }
        public async Task<IActionResult> SearchResults(string SearchPhrase)
        {
            return View("Index", await _context.Java.Where(j=>j.Question.Contains(SearchPhrase)).ToListAsync());
        }
        // GET: Java/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var java = await _context.Java
                .FirstOrDefaultAsync(m => m.Id == id);
            if (java == null)
            {
                return NotFound();
            }

            return View(java);
        }

        // GET: Java/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Java/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] Java java)
        {
            if (ModelState.IsValid)
            {
                _context.Add(java);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(java);
        }

        // GET: Java/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var java = await _context.Java.FindAsync(id);
            if (java == null)
            {
                return NotFound();
            }
            return View(java);
        }

        // POST: Java/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] Java java)
        {
            if (id != java.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(java);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JavaExists(java.Id))
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
            return View(java);
        }

        // GET: Java/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var java = await _context.Java
                .FirstOrDefaultAsync(m => m.Id == id);
            if (java == null)
            {
                return NotFound();
            }

            return View(java);
        }

        // POST: Java/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var java = await _context.Java.FindAsync(id);
            if (java != null)
            {
                _context.Java.Remove(java);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JavaExists(int id)
        {
            return _context.Java.Any(e => e.Id == id);
        }
    }
}
