using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentEnrollmentSystemContext _context;

        public CourseRepository(StudentEnrollmentSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得所有課程及相關教授資訊
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseViewModel>> GetCourseWithProfessorsAsync()
        {
            var data = await _context.Courses
                .Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Professors = c.Classes.Select(cls => new ProfessorWithClassViewModel
                    {
                        professorId = cls.ProfessorId,
                        ProfessorName = cls.Professor.Name,
                        Email = cls.Professor.Email,
                    })
                }).ToListAsync();

            return data;
        }

        public async Task<CourseViewModel?> GetCourseWithProfessorsAsync(int id)
        {
            var data = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Professors = c.Classes.Select(cls => new ProfessorWithClassViewModel
                    {
                        professorId = cls.ProfessorId,
                        ProfessorName = cls.Professor.Name,
                        Email = cls.Professor.Email,
                    })
                }).FirstOrDefaultAsync();

            return data;
        }
    }
}
