#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterListsController : ControllerBase
    {
        private readonly symphony_limitedContext _context;

        public CenterListsController(symphony_limitedContext context)
        {
            _context = context;
        }

        // GET: api/CenterLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenterList>>> GetCenterLists()
        {
            return await _context.CenterLists.ToListAsync();
        }

        // GET: api/CenterLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CenterList>> GetCenterList(int id)
        {
            var centerList = await _context.CenterLists.FindAsync(id);

            if (centerList == null)
            {
                return NotFound();
            }

            return centerList;
        }

        // PUT: api/CenterLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCenterList(int id, CenterList centerList)
        {
            if (id != centerList.Id)
            {
                return BadRequest();
            }

            _context.Entry(centerList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterListExists(id))
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

        // POST: api/CenterLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CenterList>> PostCenterList(CenterList centerList)
        {
            _context.CenterLists.Add(centerList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCenterList", new { id = centerList.Id }, centerList);
        }

        // DELETE: api/CenterLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCenterList(int id)
        {
            var centerList = await _context.CenterLists.FindAsync(id);
            if (centerList == null)
            {
                return NotFound();
            }

            _context.CenterLists.Remove(centerList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CenterListExists(int id)
        {
            return _context.CenterLists.Any(e => e.Id == id);
        }
    }
}
