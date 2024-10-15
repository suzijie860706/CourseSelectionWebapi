using Swashbuckle.AspNetCore.Filters;
using TRIDENT_Project.Models;
using TRIDENT_Project.Paramenters;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Common
{
    public class CourseParamenterExample : IExamplesProvider<CourseParamenter>
    {
        public CourseParamenter GetExamples()
        {
            return new CourseParamenter
            {
                CourseName = "國文",
            };
        }
    }

    public class CourseExample : IExamplesProvider<Course>
    {
        public Course GetExamples()
        {
            return new Course
            {
                CourseId = 1,
                CourseName = "國文",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }
    }

    public class ProfessorParamenterExample : IExamplesProvider<ProfessorParamenter>
    {
        public ProfessorParamenter GetExamples()
        {
            return new ProfessorParamenter
            {
                Email = "asdasd@gamil.com",
                Name = "王教授"
            };
        }
    }

    public class ProfessorExample : IExamplesProvider<Professor>
    {
        public Professor GetExamples()
        {
            return new Professor
            {
                ProfessorId = 1,
                Email = "asdasd@gamil.com",
                Name = "王教授",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }
    }
}
