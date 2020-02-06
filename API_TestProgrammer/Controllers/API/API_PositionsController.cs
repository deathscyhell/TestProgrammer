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
    public class API_PositionsController : ControllerBase
    {
        private readonly DataContext _context;

        public API_PositionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/API_Positions
        [HttpGet]
        public IEnumerable<Tbl_Positions> GetPositions()
        {
            return _context.Positions;
        }

        // GET: api/API_Positions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbl_Positions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Positions = await _context.Positions.FindAsync(id);

            if (tbl_Positions == null)
            {
                return NotFound();
            }

            return Ok(tbl_Positions);
        }

        // PUT: api/API_Positions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbl_Positions([FromRoute] int id, [FromBody] Tbl_Positions tbl_Positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Positions.PositionID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Positions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_PositionsExists(id))
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

        // POST: api/API_Positions
        [HttpPost]
        public async Task<IActionResult> PostTbl_Positions([FromBody] Tbl_Positions tbl_Positions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Positions.Add(tbl_Positions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_Positions", new { id = tbl_Positions.PositionID }, tbl_Positions);
        }

        // DELETE: api/API_Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_Positions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Positions = await _context.Positions.FindAsync(id);
            if (tbl_Positions == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(tbl_Positions);
            await _context.SaveChangesAsync();

            return Ok(tbl_Positions);
        }

        private bool Tbl_PositionsExists(int id)
        {
            return _context.Positions.Any(e => e.PositionID == id);
        }
    }
}