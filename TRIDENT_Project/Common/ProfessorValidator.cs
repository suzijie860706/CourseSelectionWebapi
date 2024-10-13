using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.Common
{
    /// <summary>
    /// Parameter 的驗證器
    /// </summary>
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        /// <summary>
        /// 驗證器的建構式: 在這裡註冊我們要驗證的規則
        /// </summary>
        public ProfessorValidator()
        {
            //this.RuleFor(professor => professor.Id).LessThanOrEqualTo(1);
        }
    }
}
