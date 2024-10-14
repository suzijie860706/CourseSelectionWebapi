using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.Services;

namespace TRIDENT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// 課程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await _courseService.GetAllCoursesAsync());
        }

        /// <summary>
        /// 取得特定課程
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse(int id)
        {
            Course? courses = await _courseService.GetCoursesByIdAsync(id);
            if (courses == null) return NoContent();
            return Ok(courses);
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
            try
            {
                var result = await _courseService.UpdateCourseAsync(id, course);
                if (!result)
                {
                    return Problem("Update Failed");
                }
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="courseParamenter"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Course), 201)]
        public async Task<ActionResult<Course>> PostCourse(CourseParamenter courseParamenter)
        {
            Course course = await _courseService.CreateCoursesAsync(courseParamenter);

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
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
            bool succ = await _courseService.DeleteCoursesAsync(id);

            if (!succ) return NotFound();
            return NoContent();
        }
    }
}
