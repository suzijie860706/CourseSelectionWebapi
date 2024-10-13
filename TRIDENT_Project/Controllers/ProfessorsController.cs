using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TRIDENT_Project.Models;
using TRIDENT_Project.Services;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorsService _professorsService;
        private readonly ICourseService _courseService;


        public ProfessorsController(IProfessorsService professorsService, ICourseService courseService)
        {
            _professorsService = professorsService;
            _courseService = courseService;
        }

        /// <summary>
        /// 授課講師列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), 200)]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
            return Ok(await _professorsService.GetAllProfessorsAsync());
        }

        /// <summary>
        /// 授課講師所開課程列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Professor), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Course>> GetCoursesByProfessorId(int id)
        {
            IEnumerable<Course> professorCourse = await _courseService.GetCoursesByProfessorIdAsync(id);
            if (professorCourse == null) return NoContent();
            return Ok(professorCourse);
        }

        /// <summary>
        /// 建立新講師
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(ProfessorParamenter professor)
        {
            Professor professor1 = await _professorsService.CreateProfessorAsync(professor);

            return CreatedAtAction("GetCourse", new { id = professor1.Id }, professor);
        }
    }
}
