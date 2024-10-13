using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Courses = new HashSet<Course>();
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
        /// <summary>
        /// 帳號建立時間
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 帳號更新時間
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
