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
                .ForMember(u => u.CourseId, opt => opt.Ignore())
                .ForMember(u => u.CourseName, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(u => u.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(u => u.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(u => u.UpdatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(u => u.CreatedDate, opt => opt.Ignore())
                .ForMember(u => u.ClassSchedules, opt => opt.Ignore())
                .ForMember(u => u.Classes, opt => opt.Ignore());
        }
    }
}
