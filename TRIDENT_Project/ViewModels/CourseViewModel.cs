using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.ViewModels;

namespace TRIDENT_Project.Models
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            Professors = new HashSet<ProfessorViewModel>();
        }
        /// <summary>課程Id</summary>
        public int CourseId { get; set; }

        /// <summary>課程名稱</summary>
        public string? CourseName { get; set; }

        /// <summary>課程描述</summary>
        public string? Description { get; set; }

        /// <summary>
        /// 授課教授Id
        /// </summary>
        public IEnumerable<ProfessorViewModel> Professors { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class CourseViewModelProfile : Profile
    {
        public CourseViewModelProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(u => u.CourseId, opt => opt.MapFrom(src => src.CourseId))
                .ForMember(u => u.CourseName, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(u => u.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(u => u.Professors, opt => opt.Ignore());
        }
    }
}
