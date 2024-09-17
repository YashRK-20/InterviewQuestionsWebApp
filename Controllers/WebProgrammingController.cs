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
    public class WebProgrammingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebProgrammingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WebProgramming
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebProgramming.ToListAsync());
        }
        public async Task<IActionResult> Search()
        {
            return View();
        }
        public async Task<IActionResult> SearchResults(string SearchPhrase)
        {
            return View("Index", await _context.WebProgramming.Where(j => j.Question.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: WebProgramming/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webProgramming = await _context.WebProgramming
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webProgramming == null)
            {
                return NotFound();
            }

            return View(webProgramming);
        }

        // GET: WebProgramming/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebProgramming/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] WebProgramming webProgramming)
        {
            if (ModelState.IsValid)
            {
                _context.Add(webProgramming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webProgramming);
        }

        // GET: WebProgramming/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webProgramming = await _context.WebProgramming.FindAsync(id);
            if (webProgramming == null)
            {
                return NotFound();
            }
            return View(webProgramming);
        }

        // POST: WebProgramming/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] WebProgramming webProgramming)
        {
            if (id != webProgramming.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webProgramming);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebProgrammingExists(webProgramming.Id))
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
            return View(webProgramming);
        }

        // GET: WebProgramming/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webProgramming = await _context.WebProgramming
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webProgramming == null)
            {
                return NotFound();
            }

            return View(webProgramming);
        }

        // POST: WebProgramming/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webProgramming = await _context.WebProgramming.FindAsync(id);
            if (webProgramming != null)
            {
                _context.WebProgramming.Remove(webProgramming);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebProgrammingExists(int id)
        {
            return _context.WebProgramming.Any(e => e.Id == id);
        }
    }
}
