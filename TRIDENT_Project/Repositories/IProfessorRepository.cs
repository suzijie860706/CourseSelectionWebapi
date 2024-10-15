using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Repositories
{
    public interface ICourseRepository
    {
        /// <summary>
        /// 取得所有課程及相關教授資訊
        /// </summary>
        /// <returns></returns>
        Task<List<CourseViewModel>> GetCourseWithProfessorsAsync();

        /// <summary>
        /// 取得指定課程及相關教授資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CourseViewModel?> GetCourseWithProfessorsAsync(int id);
    }
}
