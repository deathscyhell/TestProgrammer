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
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Empleoyees.Include(t => t.Positions).Include(t => t.Profiles);
            return View(await dataContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Employees = await _context.Empleoyees
                .Include(t => t.Positions)
                .Include(t => t.Profiles)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (tbl_Employees == null)
            {
                return NotFound();
            }

            return View(tbl_Employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID");
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "ProfileID", "ProfileID");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,PositionID,ProfileID")] Tbl_Employees tbl_Employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_Employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID", tbl_Employees.PositionID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "ProfileID", "ProfileID", tbl_Employees.ProfileID);
            return View(tbl_Employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Employees = await _context.Empleoyees.FindAsync(id);
            if (tbl_Employees == null)
            {
                return NotFound();
            }
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID", tbl_Employees.PositionID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "ProfileID", "ProfileID", tbl_Employees.ProfileID);
            return View(tbl_Employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,PositionID,ProfileID")] Tbl_Employees tbl_Employees)
        {
            if (id != tbl_Employees.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_Employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tbl_EmployeesExists(tbl_Employees.EmployeeID))
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
            ViewData["PositionID"] = new SelectList(_context.Positions, "PositionID", "PositionID", tbl_Employees.PositionID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "ProfileID", "ProfileID", tbl_Employees.ProfileID);
            return View(tbl_Employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_Employees = await _context.Empleoyees
                .Include(t => t.Positions)
                .Include(t => t.Profiles)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (tbl_Employees == null)
            {
                return NotFound();
            }

            return View(tbl_Employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_Employees = await _context.Empleoyees.FindAsync(id);
            _context.Empleoyees.Remove(tbl_Employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tbl_EmployeesExists(int id)
        {
            return _context.Empleoyees.Any(e => e.EmployeeID == id);
        }
    }
}
