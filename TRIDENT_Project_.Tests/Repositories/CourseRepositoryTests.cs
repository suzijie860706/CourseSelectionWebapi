using TRIDENT_Project.Models;

namespace TRIDENT_Project.Tests.Repositories
{
    [TestFixture]
    public class CustomerRepositoryTests : CRUDRepositoryTestsBase<Course>
    {
        protected override void SeedData()
        {
            _dbset.Add(new Course
            {
                CourseId = 1,
                CourseName = "數學",
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            });
        }
    }
}