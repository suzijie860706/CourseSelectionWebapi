using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.ViewModel
{
    [ModelMetadataType(typeof(IProfessorMetaData))]
    public partial class ProfessorViewModel
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 教授姓名
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
