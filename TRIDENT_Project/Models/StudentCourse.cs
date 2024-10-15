using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class StudentCourse
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int StudentCourseId { get; set; }
        /// <summary>
        /// 學生Id
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 課程Id
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 教授Id
        /// </summary>
        public int ProfessorId { get; set; }
        /// <summary>
        /// 選課日期
        /// </summary>
        public DateTime EnrollDate { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
