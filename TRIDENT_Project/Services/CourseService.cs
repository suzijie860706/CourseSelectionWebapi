using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.Repositories;

namespace TRIDENT_Project.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICRUDRepository<Course> _repository;
        private IMapper _mapper;

        public CourseService(ICRUDRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 課程列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _repository.FindAsync(_ => true);
        }

        /// <summary>
        /// 取得特定課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Course?> GetCoursesByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        /// <summary>
        /// 授課講師所開課程列表
        /// </summary>
        /// <param name="professorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCoursesByProfessorIdAsync(int professorId)
        {
            return await _repository.FindAsync(x => x.ProfessorId == professorId);
        }

        /// <summary>
        /// 更新課程內容
        /// </summary>
        /// <param name="id">課程ID</param>
        /// <param name="course">更新後的課程對象</param>
        /// <returns>是否更新成功</returns>
        /// <exception cref="ArgumentException">如果 ID 不匹配，會拋出該異常</exception>
        /// <exception cref="KeyNotFoundException">如果找不到該課程，會拋出該異常</exception>
        public async Task<bool> UpdateCourseAsync(int id, Course course)
        {
            if (id != course.Id)
                throw new ArgumentException("Course ID mismatch");

            //查詢課程是否存在，不存在則拋出 KeyNotFoundException
            Course? existingCourse = await _repository.FindByIdAsync(id);
            if (existingCourse == null)
                throw new KeyNotFoundException($"Course ID:{id} was not found");

            //更新課程
            int count = await _repository.UpdateAsync(course);
            return count > 0;
        }




        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="courseParamenter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Course> CreateCoursesAsync(CourseParamenter courseParamenter)
        {
            Course course = _mapper.Map<Course>(courseParamenter);
            Course? createdCourse = await _repository.CreateAsync(course);
            if (createdCourse == null)
            {
                throw new Exception("新增失敗");
            }
            return createdCourse;
        }


        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCoursesAsync(int id)
        {
            Course? course = await _repository.FindByIdAsync(id);
            if (course == null) return false;

            await _repository.DeleteAsync(course);
            return true;
        }

    }
}
