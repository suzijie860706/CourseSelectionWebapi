using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class Class
    {
        public Class()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        /// <summary>
        /// 課表Id
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 課程Id
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 教授Id
        /// </summary>
        public int ProfessorId { get; set; }
        /// <summary>
        /// 班級名稱
        /// </summary>
        public string? ClassName { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Professor Professor { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
