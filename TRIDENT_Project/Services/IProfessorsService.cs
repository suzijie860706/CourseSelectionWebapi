using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Services
{
    public interface IProfessorsService
    {
        /// <summary>
        /// 授課講師列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();

        /// <summary>
        /// 授課講師所開課程列表
        /// </summary>
        /// <param name="professorId"></param>
        /// <returns></returns>
        Task<ProfessorViewModel?> GetProfessorsWithCourseAsync(int professorId);

        /// <summary>
        /// 建立新講師
        /// </summary>
        /// <param name="Professor"></param>
        /// <returns></returns>
        Task<Professor> CreateProfessorAsync(ProfessorParamenter Professor);
    }
}
