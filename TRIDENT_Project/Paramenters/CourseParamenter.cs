using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Paramenters
{
    public class CourseParamenter
    {
        /// <summary>
        /// 課程名稱
        /// </summary>
        [Required]
        public string CourseName { get; set; } = null!;
        /// <summary>
        /// 說明
        /// </summary>
        public string? Description { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class CourseParamenterProfile : Profile
    {
        public CourseParamenterProfile()
        {
            CreateMap<CourseParamenter, Course>()
                .ForMember(dest => dest.CourseId, src =>  src.Ignore())
                .ForMember(dest => dest.CourseName, src => src.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, src => src.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.CreatedDate, src => src.Ignore())
                .ForMember(dest => dest.ClassSchedules, src => src.Ignore())
                .ForMember(dest => dest.Classes, src => src.Ignore());
        }
    }
}
