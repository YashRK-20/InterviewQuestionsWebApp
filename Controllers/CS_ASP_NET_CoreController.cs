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
    public class CS_ASP_NET_CoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CS_ASP_NET_CoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CS_ASP_NET_Core
        public async Task<IActionResult> Index()
        {
            return View(await _context.CS_ASP_NET_Core.ToListAsync());
        }
        public async Task<IActionResult> Search()
        {
            return View();
        }

        // GET: CS_ASP_NET_Core/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_ASP_NET_Core = await _context.CS_ASP_NET_Core
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cS_ASP_NET_Core == null)
            {
                return NotFound();
            }

            return View(cS_ASP_NET_Core);
        }

        // GET: CS_ASP_NET_Core/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CS_ASP_NET_Core/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] CS_ASP_NET_Core cS_ASP_NET_Core)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cS_ASP_NET_Core);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cS_ASP_NET_Core);
        }

        // GET: CS_ASP_NET_Core/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_ASP_NET_Core = await _context.CS_ASP_NET_Core.FindAsync(id);
            if (cS_ASP_NET_Core == null)
            {
                return NotFound();
            }
            return View(cS_ASP_NET_Core);
        }

        // POST: CS_ASP_NET_Core/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] CS_ASP_NET_Core cS_ASP_NET_Core)
        {
            if (id != cS_ASP_NET_Core.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cS_ASP_NET_Core);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CS_ASP_NET_CoreExists(cS_ASP_NET_Core.Id))
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
            return View(cS_ASP_NET_Core);
        }

        // GET: CS_ASP_NET_Core/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cS_ASP_NET_Core = await _context.CS_ASP_NET_Core
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cS_ASP_NET_Core == null)
            {
                return NotFound();
            }

            return View(cS_ASP_NET_Core);
        }

        // POST: CS_ASP_NET_Core/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cS_ASP_NET_Core = await _context.CS_ASP_NET_Core.FindAsync(id);
            if (cS_ASP_NET_Core != null)
            {
                _context.CS_ASP_NET_Core.Remove(cS_ASP_NET_Core);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CS_ASP_NET_CoreExists(int id)
        {
            return _context.CS_ASP_NET_Core.Any(e => e.Id == id);
        }
    }
}
