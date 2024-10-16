using AutoMapper;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.Paramenters
{
    public class CourseUpdateParamenter : CourseParamenter
    {
        /// <summary>
        /// 課程Id
        /// </summary>
        public int? CourseId { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class CourseUpdateParamenterProfile : Profile
    {
        public CourseUpdateParamenterProfile()
        {
            CreateMap<CourseUpdateParamenter, Course>()
                .ForMember(dest => dest.CourseId, src => src.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CourseName, src => src.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.Description, src => src.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom((src, dest) => dest.CreatedDate))
                .ForMember(dest => dest.UpdatedDate, src => src.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ClassSchedules, src => src.Ignore())
                .ForMember(dest => dest.Classes, src => src.Ignore());
        }
    }
}
