using TRIDENT_Project.Models;

namespace TRIDENT_Project.Repositories
{
    public interface IProfessorRepository
    {
        Task<Professor?> GetProfessorsWithCourseAsync(int professorId);
    }
}
