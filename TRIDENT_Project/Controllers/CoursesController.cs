using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly StudentEnrollmentSystemContext _context;

        public CoursesController(StudentEnrollmentSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 課程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }


        /// <summary>
        /// 更新課程內容
        /// </summary>
        /// <param name="id">課程id</param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CourseExists(id))
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

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCourse", new { id = course.Id }, course);
            }
            catch (DbUpdateException)
            {
                if (await CourseExists(course.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id">課程id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CourseExists(int id)
        {
            if (_context.Courses == null) return false;
            return await _context.Courses.AnyAsync(e => e.Id == id) ;
        }
    }
}
