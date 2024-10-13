using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TRIDENT_Project.Models;
using TRIDENT_Project.Extensions;

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
                .IgnoreAllUnmapped()
                .ForMember(u => u.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(u => u.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(u => u.UpdatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(u => u.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
