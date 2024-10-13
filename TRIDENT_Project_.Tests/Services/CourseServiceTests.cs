using TRIDENT_Project.Services;
using TRIDENT_Project.Repositories;
using TRIDENT_Project.Models;
using NSubstitute;
using AutoMapper;
using TRIDENT_Project.Paramenters;

namespace TRIDENT_Project.Tests.Services
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CourseServiceTests
    {
        private ICRUDRepository<Course> _repository;
        private CourseService _courseService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ICRUDRepository<Course>>();
            _courseService = new CourseService(_repository, _mapper);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                // 手動添加所有的 AutoMapper Profile
                cfg.AddProfile(new CourseParamenterProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Test]
        public void MapperConfiguration_ShouldBeValid()
        {
            //Act
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(1 , true)]
        [TestCase(0, false)]
        public async Task UpdateCourseAsync_WhenCalled_ReturnsExpectedResult(int affectRow, bool output)
        {
            //Arrange
            int id = 1;
            Course course = new Course()
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 3,
            };
            _repository.FindByIdAsync(id).Returns(course);
            _repository.UpdateAsync(Arg.Any<Course>()).Returns(affectRow);

            //Act
            bool result = await _courseService.UpdateCourseAsync(id, course);

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        public async Task UpdateCourseAsync_WhenCalled_ThrowsArgumentException()
        {
            //Arrange
            int id = 2;
            Course course = new Course()
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 3,
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _courseService.UpdateCourseAsync(id, course), "Course ID mismatch");
        }

        [Test]
        public async Task UpdateCourseAsync_WhenCalled_ThrowsKeyNotFoundException()
        {
            //Arrange
            int id = 1;
            Course course = new Course()
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 3,
            };
            _repository.FindByIdAsync(id).Returns((Course?)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await _courseService.UpdateCourseAsync(id, course), $"Course ID:{id} was not found");
        }
    }
}
