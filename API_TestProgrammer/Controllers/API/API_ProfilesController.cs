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
    public class API_ProfilesController : ControllerBase
    {
        private readonly DataContext _context;

        public API_ProfilesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/API_Profiles
        [HttpGet]
        public IEnumerable<Tbl_Profiles> GetProfiles()
        {
            return _context.Profiles;
        }

        // GET: api/API_Profiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTbl_Profiles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Profiles = await _context.Profiles.FindAsync(id);

            if (tbl_Profiles == null)
            {
                return NotFound();
            }

            return Ok(tbl_Profiles);
        }

        // PUT: api/API_Profiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbl_Profiles([FromRoute] int id, [FromBody] Tbl_Profiles tbl_Profiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Profiles.ProfileID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Profiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_ProfilesExists(id))
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

        // POST: api/API_Profiles
        [HttpPost]
        public async Task<IActionResult> PostTbl_Profiles([FromBody] Tbl_Profiles tbl_Profiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profiles.Add(tbl_Profiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_Profiles", new { id = tbl_Profiles.ProfileID }, tbl_Profiles);
        }

        // DELETE: api/API_Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_Profiles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tbl_Profiles = await _context.Profiles.FindAsync(id);
            if (tbl_Profiles == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(tbl_Profiles);
            await _context.SaveChangesAsync();

            return Ok(tbl_Profiles);
        }

        private bool Tbl_ProfilesExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfileID == id);
        }
    }
}