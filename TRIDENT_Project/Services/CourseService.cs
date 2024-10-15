using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.Repositories;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICRUDRepository<Course> _repository;
        private readonly ICourseRepository _courseRepository;
        private IMapper _mapper;

        public CourseService(ICRUDRepository<Course> repository, IMapper mapper, ICourseRepository courseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// 課程列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseViewModel>> GetAllCoursesAsync()
        {
            List<CourseViewModel> result = await _courseRepository.GetCourseWithProfessorsAsync();
            return result;
        }

        /// <summary>
        /// 取得特定課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CourseViewModel?> GetCoursesByIdAsync(int id)
        {
            return await _courseRepository.GetCourseWithProfessorsAsync(id);
        }

        /// <summary>
        /// 更新課程內容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseUpdateParamenter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">如果 ID 不匹配，會拋出該異常</exception>
        public async Task<bool> UpdateCourseAsync(int id, CourseUpdateParamenter courseUpdateParamenter)
        {
            Course course = _mapper.Map<Course>(courseUpdateParamenter);
            if (id != course.CourseId)
                throw new ArgumentException("RouterId not macth courseId");

            //查詢課程是否存在，不存在則拋出 KeyNotFoundException
            Course? existingCourse = await _repository.FindByIdAsync(id);
            if (existingCourse == null) return false;

            //更新課程
            await _repository.UpdateAsync(course);
            return true;
        }

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="courseParamenter"></param>
        /// <returns></returns>
        public async Task<CourseViewModel> CreateCoursesAsync(CourseParamenter courseParamenter)
        {
            Course course = _mapper.Map<Course>(courseParamenter);
            Course createdCourse = await _repository.CreateAsync(course);
            CourseViewModel result = _mapper.Map<CourseViewModel>(createdCourse);

            return result;
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
