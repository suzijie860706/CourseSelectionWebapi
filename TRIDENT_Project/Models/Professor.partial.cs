using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TRIDENT_Project.Models
{
    [ModelMetadataType(typeof(IProfessorMetaData))]
    public partial class Professor : IProfessorMetaData
    { }

    public interface IProfessorMetaData
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// 教授姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 電子郵件地址
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 帳號建立時間
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 帳號更新時間
        /// </summary>
        [JsonIgnore]
        public DateTime UpdatedTime { get; set; }

        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
    }
}
