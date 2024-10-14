using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// 授課教授Id
        /// </summary>
        public int? ProfessorId { get; set; }
        /// <summary>
        /// 課程建立時間
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// 課程更新時間
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        public DateTime? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual Professor? Professor { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
