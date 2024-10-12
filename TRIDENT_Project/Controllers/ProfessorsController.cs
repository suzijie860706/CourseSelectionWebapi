using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly StudentEnrollmentSystemContext _context;

        public ProfessorsController(StudentEnrollmentSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 授課講師列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), 200)]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            return await _context.Professors.ToListAsync();
        }

        /// <summary>
        /// 授課講師所開課程列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Professor), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
          if (_context.Professors == null)
          {
              return NotFound();
          }
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        /// <summary>
        /// 建立新講師
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(ProfessorViewModel professor)
        {
            //if (_context.Professors == null)
            //{
            //    return Problem("Entity set 'StudentEnrollmentSystemContext.Professors'  is null.");
            //}
            //  _context.Professors.Add(professor);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetProfessor", new { id = professor.Id }, professor);
            return Ok();
        }
        private bool ProfessorExists(int id)
        {
            return (_context.Professors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
