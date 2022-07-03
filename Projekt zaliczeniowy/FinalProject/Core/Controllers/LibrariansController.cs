using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Core.Controllers
{
    //[Authorize]
    public class LibrariansController : Controller
    {
        private readonly Entities.AppContext _context;

        public LibrariansController(Entities.AppContext context)
        {
            _context = context;
        }

        // GET: Librarians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Librarians.ToListAsync());
        }

        // GET: Librarians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarians = await _context.Librarians
                .FirstOrDefaultAsync(m => m.LId == id);
            if (librarians == null)
            {
                return NotFound();
            }

            return View(librarians);
        }

        // GET: Librarians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Librarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Create([Bind("LId,LFirstName,LLastName,LEmail")] Librarians librarians)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librarians);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(librarians);
        }

        // GET: Librarians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarians = await _context.Librarians.FindAsync(id);
            if (librarians == null)
            {
                return NotFound();
            }
            return View(librarians);
        }

        // POST: Librarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Edit(int id, [Bind("LId,LFirstName,LLastName,LEmail")] Librarians librarians)
        {
            if (id != librarians.LId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librarians);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrariansExists(librarians.LId))
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
            return View(librarians);
        }

        // GET: Librarians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarians = await _context.Librarians
                .FirstOrDefaultAsync(m => m.LId == id);
            if (librarians == null)
            {
                return NotFound();
            }

            return View(librarians);
        }

        // POST: Librarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librarians = await _context.Librarians.FindAsync(id);
            _context.Librarians.Remove(librarians);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrariansExists(int id)
        {
            return _context.Librarians.Any(e => e.LId == id);
        }
    }
}
