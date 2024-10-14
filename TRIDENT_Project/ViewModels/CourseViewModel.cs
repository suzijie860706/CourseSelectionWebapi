using AutoMapper;
using System;
using System.Collections.Generic;
using TRIDENT_Project.Paramenters;

namespace TRIDENT_Project.Models
{
    public class CourseViewModel
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string? CourseName { get; set; }
        /// <summary>
        /// 授課教授Id
        /// </summary>
        public int? ProfessorId { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class CourseViewModelProfile : Profile
    {
        public CourseViewModelProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(u => u.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(u => u.CourseName, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(u => u.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId));
        }
    }
}
