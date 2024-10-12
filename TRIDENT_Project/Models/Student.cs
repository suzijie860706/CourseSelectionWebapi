using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
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
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 帳號更新時間
        /// </summary>
        public DateTime UpdatedTime { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
