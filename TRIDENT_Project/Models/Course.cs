using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Course
    {
        public Course()
        {
            ClassSchedules = new HashSet<ClassSchedule>();
            Classes = new HashSet<Class>();
        }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseName { get; set; } = null!;
        /// <summary>
        /// 說明
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 課程建立時間
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// 課程更新時間
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
