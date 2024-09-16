using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewQuestions.Data;
using InterviewQuestions.Models;

namespace InterviewQuestions.Controllers
{
    public class SQLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SQLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SQL
        public async Task<IActionResult> Index()
        {
            return View(await _context.SQL.ToListAsync());
        }

        // GET: SQL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sQL = await _context.SQL
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sQL == null)
            {
                return NotFound();
            }

            return View(sQL);
        }

        // GET: SQL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SQL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] SQL sQL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sQL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sQL);
        }

        // GET: SQL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sQL = await _context.SQL.FindAsync(id);
            if (sQL == null)
            {
                return NotFound();
            }
            return View(sQL);
        }

        // POST: SQL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] SQL sQL)
        {
            if (id != sQL.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sQL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SQLExists(sQL.Id))
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
            return View(sQL);
        }

        // GET: SQL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sQL = await _context.SQL
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sQL == null)
            {
                return NotFound();
            }

            return View(sQL);
        }

        // POST: SQL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sQL = await _context.SQL.FindAsync(id);
            if (sQL != null)
            {
                _context.SQL.Remove(sQL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SQLExists(int id)
        {
            return _context.SQL.Any(e => e.Id == id);
        }
    }
}
