using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TRIDENT_Project.Models
{
    [ModelMetadataType(typeof(StudentMetaData))]
    public partial class Student { }

    internal partial class StudentMetaData
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// 學生姓名
        /// </summary>
        public string Name { get; set; } = null!;
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
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
