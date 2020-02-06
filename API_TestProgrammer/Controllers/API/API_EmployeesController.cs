using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TestProgrammer.Models;
using TestProgrammer_API.Models;

namespace API_TestProgrammer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public API_EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/API_Employees
        [HttpGet]
        public IEnumerable<Tbl_Employees> GetEmpleoyees()
        {
            return _context.Empleoyees;
        }

        // GET: api/API_Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbl_Employees([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Employees = await _context.Empleoyees.FindAsync(id);

            if (tbl_Employees == null)
            {
                return NotFound();
            }

            return Ok(tbl_Employees);
        }

        // PUT: api/API_Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbl_Employees([FromRoute] int id, [FromBody] Tbl_Employees tbl_Employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Employees.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/API_Employees
        [HttpPost]
        public async Task<IActionResult> PostTbl_Employees([FromBody] Tbl_Employees tbl_Employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Empleoyees.Add(tbl_Employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_Employees", new { id = tbl_Employees.EmployeeID }, tbl_Employees);
        }

        // DELETE: api/API_Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_Employees([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Employees = await _context.Empleoyees.FindAsync(id);
            if (tbl_Employees == null)
            {
                return NotFound();
            }

            _context.Empleoyees.Remove(tbl_Employees);
            await _context.SaveChangesAsync();

            return Ok(tbl_Employees);
        }

        private bool Tbl_EmployeesExists(int id)
        {
            return _context.Empleoyees.Any(e => e.EmployeeID == id);
        }
    }
}