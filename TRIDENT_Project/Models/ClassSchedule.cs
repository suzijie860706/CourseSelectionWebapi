using System;
using System.Collections.Generic;

namespace TRIDENT_Project.Models
{
    public partial class ClassSchedule
    {
        /// <summary>
        /// 課表排程Id
        /// </summary>
        public int ScheduleId { get; set; }
        /// <summary>
        /// 課程Id
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 星期
        /// </summary>
        public byte? DayOfWeek { get; set; }
        /// <summary>
        /// 上課時間
        /// </summary>
        public TimeSpan? StartTime { get; set; }
        /// <summary>
        /// 下課時間
        /// </summary>
        public TimeSpan? EndTime { get; set; }
        public string? Location { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
