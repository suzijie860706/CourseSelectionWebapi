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
        private ICourseRepository _courseRepository;
        private CourseService _courseService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ICRUDRepository<Course>>();
            _courseRepository = Substitute.For<ICourseRepository>();
            _courseService = new CourseService(_repository, _mapper,_courseRepository);

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
        public async Task UpdateCourseAsync_WhenCalled_Returns()
        {
            //Arrange
            int id = 1;
            CourseUpdateParamenter course = new CourseUpdateParamenter()
            {
                CourseId = 1,
                CourseName = "國文",
            };

            _repository.FindByIdAsync(id).Returns(new Course());
            await _repository.UpdateAsync(Arg.Any<Course>());

            //Act
            await _courseService.UpdateCourseAsync(id, course);

            //Assert
        }

        [Test]
        public async Task UpdateCourseAsync_WhenCalled_ThrowsArgumentException()
        {
            //Arrange
            int id = 2;
            CourseUpdateParamenter courseUpdateParamenter = new CourseUpdateParamenter()
            {
                CourseId = 1,
                CourseName = "國文",
            };

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _courseService.UpdateCourseAsync(id, courseUpdateParamenter), "Course ID mismatch");
        }

        [Test]
        public async Task UpdateCourseAsync_WhenCalled_ThrowsKeyNotFoundException()
        {
            //Arrange
            int id = 1;
            CourseUpdateParamenter course = new CourseUpdateParamenter()
            {
                CourseId = 1,
                CourseName = "國文",
            };
            _repository.FindByIdAsync(id).Returns((Course?)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await _courseService.UpdateCourseAsync(id, course), $"Course ID:{id} was not found");
        }
    }
}
