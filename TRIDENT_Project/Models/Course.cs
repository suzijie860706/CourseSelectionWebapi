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
        public string? CourseName { get; set; }
        public int? ProfessorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public virtual Professor? Professor { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
