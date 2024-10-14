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
                ProfessorId = 1
            };
        }
    }

    public class CourseExample : IExamplesProvider<Course>
    {
        public Course GetExamples()
        {
            return new Course
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 1,
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
                Id = 1,
                Email = "asdasd@gamil.com",
                Name = "王教授",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }
    }
}
