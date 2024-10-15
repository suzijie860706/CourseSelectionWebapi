using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.Services;
using TRIDENT_Project.ViewModels;

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
        [ProducesResponseType(typeof(IEnumerable<CourseViewModel>), 200)]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
        {
            var result = await _courseService.GetAllCoursesAsync();
            return Ok(result);
        }

        /// <summary>
        /// 取得特定課程
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseViewModel), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CourseViewModel>> GetCourse(int id)
        {
            CourseViewModel? result = await _courseService.GetCoursesByIdAsync(id);
            if (result == null) return NoContent();
            return Ok(result);
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
        public async Task<IActionResult> PutCourse(int id, CourseUpdateParamenter course)
        {
            try
            {
                bool succ = await _courseService.UpdateCourseAsync(id, course);
                if (!succ) return NotFound();
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="courseParamenter"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CourseViewModel), 201)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<CourseViewModel>> PostCourse(CourseParamenter courseParamenter)
        {
            try
            {
                CourseViewModel course = await _courseService.CreateCoursesAsync(courseParamenter);
                return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
            }
            catch (DbUpdateException)
            {
                return Conflict($"課程\"{courseParamenter.CourseName}\"已存在，重複建立");
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
            bool succ = await _courseService.DeleteCoursesAsync(id);

            if (!succ) return NotFound();
            return NoContent();
        }
    }
}
