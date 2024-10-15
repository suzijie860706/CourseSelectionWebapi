using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Services
{
    public interface ICourseService
    {

        /// <summary>
        /// 課程列表
        /// </summary>
        /// <returns></returns>
        Task<List<CourseViewModel>> GetAllCoursesAsync();

        /// <summary>
        /// 取得特定課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CourseViewModel?> GetCoursesByIdAsync(int id);

        /// <summary>
        /// 更新課程內容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task UpdateCourseAsync(int id, CourseUpdateParamenter customer);

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="courseParamenter"></param>
        /// <returns></returns>
        Task<Course> CreateCoursesAsync(CourseParamenter courseParamenter);

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCoursesAsync(int id);
    }
}
