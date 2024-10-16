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
            Professors = new HashSet<ProfessorWithClassViewModel>();
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
        public IEnumerable<ProfessorWithClassViewModel> Professors { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class CourseViewModelProfile : Profile
    {
        public CourseViewModelProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(dest => dest.CourseId, src => src.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CourseName, src => src.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
                .ForMember(dest => dest.Professors, src => src.Ignore())
                .ReverseMap();
        }
    }
}
