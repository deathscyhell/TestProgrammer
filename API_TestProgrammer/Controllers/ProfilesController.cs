using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API_TestProgrammer.Models;
using TestProgrammer_API.Models;

namespace API_TestProgrammer.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly DataContext _context;

        public ProfilesController(DataContext context)
        {
            _context = context;
        }

        // GET: Profiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profiles.ToListAsync());
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Profiles = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (tbl_Profiles == null)
            {
                return NotFound();
            }

            return View(tbl_Profiles);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileID,ProfileName")] Tbl_Profiles tbl_Profiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Profiles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Profiles);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Profiles = await _context.Profiles.FindAsync(id);
            if (tbl_Profiles == null)
            {
                return NotFound();
            }
            return View(tbl_Profiles);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileID,ProfileName")] Tbl_Profiles tbl_Profiles)
        {
            if (id != tbl_Profiles.ProfileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Profiles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tbl_ProfilesExists(tbl_Profiles.ProfileID))
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
            return View(tbl_Profiles);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Profiles = await _context.Profiles
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (tbl_Profiles == null)
            {
                return NotFound();
            }

            return View(tbl_Profiles);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Profiles = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(tbl_Profiles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tbl_ProfilesExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfileID == id);
        }
    }
}
