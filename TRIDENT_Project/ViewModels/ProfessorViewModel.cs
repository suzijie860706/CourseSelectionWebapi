using AutoMapper;
using System.Text.Json.Serialization;
using TRIDENT_Project.Models;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel()
        {
            Classes = new HashSet<Class>();
        }

        /// <summary>
        /// 教授Id
        /// </summary>
        public int professorId { get; set; }
        /// <summary>
        /// 教授姓名
        /// </summary>
        public string? ProfessorName { get; set; }
        /// <summary>
        /// 電子郵件地址
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 班級名稱
        /// </summary>
        public string? ClassName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class ProfessorParamenterProfile : Profile
    {
        public ProfessorParamenterProfile()
        {
            CreateMap<Professor, ProfessorViewModel>()
                .ForMember(u => u.professorId, opt => opt.MapFrom(src => src.ProfessorId))
                .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(u => u.ProfessorName, opt => opt.MapFrom(src => src.Name))
                .ForMember(u => u.Classes, opt => opt.MapFrom(src => src.Classes))
                .ForMember(u => u.ClassName, opt => opt.Ignore());
        }
    }
}
