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
    public class PositionsController : Controller
    {
        private readonly DataContext _context;

        public PositionsController(DataContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Positions.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Positions = await _context.Positions
                .FirstOrDefaultAsync(m => m.PositionID == id);
            if (tbl_Positions == null)
            {
                return NotFound();
            }

            return View(tbl_Positions);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionID,PositionName")] Tbl_Positions tbl_Positions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Positions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_Positions);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Positions = await _context.Positions.FindAsync(id);
            if (tbl_Positions == null)
            {
                return NotFound();
            }
            return View(tbl_Positions);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,PositionName")] Tbl_Positions tbl_Positions)
        {
            if (id != tbl_Positions.PositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Positions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tbl_PositionsExists(tbl_Positions.PositionID))
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
            return View(tbl_Positions);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Positions = await _context.Positions
                .FirstOrDefaultAsync(m => m.PositionID == id);
            if (tbl_Positions == null)
            {
                return NotFound();
            }

            return View(tbl_Positions);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Positions = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(tbl_Positions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tbl_PositionsExists(int id)
        {
            return _context.Positions.Any(e => e.PositionID == id);
        }
    }
}
