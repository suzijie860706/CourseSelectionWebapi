using AutoMapper;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Paramenters
{
    public class CourseParamenter
    {
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
    public class CourseParamenterProfile : Profile
    {
        public CourseParamenterProfile()
        {
            CreateMap<CourseParamenter, Course>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.Description, opt => opt.Ignore())
                .ForMember(u => u.EndTime, opt => opt.Ignore())
                .ForMember(u => u.StartTime, opt => opt.Ignore())
                .ForMember(u => u.CourseName, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(u => u.ProfessorId, opt => opt.MapFrom(src => src.ProfessorId))
                .ForMember(u => u.UpdatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(u => u.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(u => u.Professor, opt => opt.Ignore())
                .ForMember(u => u.StudentCourses, opt => opt.Ignore());
        }
    }
}
