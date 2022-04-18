#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphone.Models;

namespace Symphone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseListsController : ControllerBase
    {
        private readonly Symphony_LimitedContext _context;

        public CourseListsController(Symphony_LimitedContext context)
        {
            _context = context;
        }

        // GET: api/CourseLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseList>>> GetCourseLists()
        {
            return await _context.CourseLists.ToListAsync();
        }

        // GET: api/CourseLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseList>> GetCourseList(int id)
        {
            var courseList = await _context.CourseLists.FindAsync(id);

            if (courseList == null)
            {
                return NotFound();
            }

            return courseList;
        }

        // PUT: api/CourseLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseList(int id, CourseList courseList)
        {
            if (id != courseList.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseListExists(id))
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

        // POST: api/CourseLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseList>> PostCourseList(CourseList courseList)
        {
            _context.CourseLists.Add(courseList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseList", new { id = courseList.Id }, courseList);
        }

        // DELETE: api/CourseLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseList(int id)
        {
            var courseList = await _context.CourseLists.FindAsync(id);
            if (courseList == null)
            {
                return NotFound();
            }

            _context.CourseLists.Remove(courseList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseListExists(int id)
        {
            return _context.CourseLists.Any(e => e.Id == id);
        }
    }
}
