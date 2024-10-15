using Microsoft.AspNetCore.Mvc;
using TRIDENT_Project.Models;
using TRIDENT_Project.Services;
using TRIDENT_Project.ViewModel;
using TRIDENT_Project.ViewModels;

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
        [ProducesResponseType(typeof(ProfessorViewModel), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<ProfessorViewModel>> GetCoursesByProfessorId(int id)
        {
            ProfessorViewModel? professorCourse = await _professorsService.GetProfessorsWithCourseAsync(id);
            if (professorCourse == null) return NoContent();
            return Ok(professorCourse);
        }

        /// <summary>
        /// 建立新講師
        /// </summary>
        /// <param name="professorParamenter"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Professor), 201)]
        public async Task<ActionResult<Professor>> PostProfessor(ProfessorParamenter professorParamenter)
        {
            Professor professor = await _professorsService.CreateProfessorAsync(professorParamenter);
            return CreatedAtAction("GetCoursesByProfessorId", new { id = professor.ProfessorId }, professor);
        }
    }
}
