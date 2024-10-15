using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Classes = new HashSet<Class>();
        }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int ProfessorId { get; set; }
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

        public virtual ICollection<Class> Classes { get; set; }
    }
}
