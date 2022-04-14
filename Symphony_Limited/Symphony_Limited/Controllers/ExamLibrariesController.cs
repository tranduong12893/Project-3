﻿#nullable disable
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
    public class ExamLibrariesController : ControllerBase
    {
        private readonly symphony_limitedContext _context;

        public ExamLibrariesController(symphony_limitedContext context)
        {
            _context = context;
        }

        // GET: api/ExamLibraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamLibrary>>> GetExamLibraries()
        {
            return await _context.ExamLibraries.ToListAsync();
        }

        // GET: api/ExamLibraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamLibrary>> GetExamLibrary(int id)
        {
            var examLibrary = await _context.ExamLibraries.FindAsync(id);

            if (examLibrary == null)
            {
                return NotFound();
            }

            return examLibrary;
        }

        // PUT: api/ExamLibraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamLibrary(int id, ExamLibrary examLibrary)
        {
            if (id != examLibrary.Id)
            {
                return BadRequest();
            }

            _context.Entry(examLibrary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamLibraryExists(id))
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

        // POST: api/ExamLibraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamLibrary>> PostExamLibrary(ExamLibrary examLibrary)
        {
            _context.ExamLibraries.Add(examLibrary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamLibrary", new { id = examLibrary.Id }, examLibrary);
        }

        // DELETE: api/ExamLibraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamLibrary(int id)
        {
            var examLibrary = await _context.ExamLibraries.FindAsync(id);
            if (examLibrary == null)
            {
                return NotFound();
            }

            _context.ExamLibraries.Remove(examLibrary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamLibraryExists(int id)
        {
            return _context.ExamLibraries.Any(e => e.Id == id);
        }
    }
}
