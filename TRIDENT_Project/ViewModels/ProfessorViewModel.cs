using AutoMapper;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            Courses = new HashSet<CourseViewModel>();
        }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 教授姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 電子郵件地址
        /// </summary>
        public string? Email { get; set; }

        public virtual ICollection<CourseViewModel> Courses { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class ProfessorParamenterProfile : Profile
    {
        public ProfessorParamenterProfile()
        {
            CreateMap<Professor, ProfessorViewModel>()
                .ForMember(u => u.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(u => u.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(u => u.Courses, opt => opt.MapFrom(src => src.Courses));
        }
    }
}
