using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly StudentEnrollmentSystemContext _context;

        public ProfessorRepository(StudentEnrollmentSystemContext context)
        {
            _context = context;
        }

        public async Task<Professor?> GetProfessorsWithCourseAsync(int professorId)
        {
            return await _context.Professors
           .Include(p => p.Courses)
           .Where(c => c.Id == professorId).FirstOrDefaultAsync();
        }
    }
}
