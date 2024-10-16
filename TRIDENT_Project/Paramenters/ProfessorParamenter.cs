using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TRIDENT_Project.Models;
using TRIDENT_Project.Attributes;

namespace TRIDENT_Project.ViewModel
{
    public class ProfessorParamenter
    {
        /// <summary>
        /// 教授姓名
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 電子郵件地址
        /// </summary>
        [Required(ErrorMessage = "請輸入Email地址")]
        [EmailValidate(ErrorMessage = "Email格式錯誤")]
        [EmailLength(minimumLength: 6, maximumLength: 30)]
        public string? Email { get; set; }
    }

    /// <summary>
    /// Mapper使用
    /// </summary>
    public class ProfessorParamenterProfile : Profile
    {
        public ProfessorParamenterProfile()
        {
            CreateMap<ProfessorParamenter, Professor>()
                .ForMember(dest => dest.ProfessorId, src => src.Ignore())
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.UpdatedDate, src => src.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.Classes, src => src.Ignore());
        }
    }
}
