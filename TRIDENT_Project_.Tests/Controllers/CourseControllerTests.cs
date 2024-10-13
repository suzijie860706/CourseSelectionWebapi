using NSubstitute;
using TRIDENT_Project.Controllers;
using TRIDENT_Project.Services;
using TRIDENT_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace TRIDENT_Project.Tests.Controllers
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CoursesControllerTests
    {
        private ICourseService _courseService;
        private CoursesController _controller;

        [SetUp]
        public void SetUp()
        {
            _courseService = Substitute.For<ICourseService>();
            _controller = new CoursesController(_courseService);
        }

        [Test]
        public async Task PutCourse_WhenCalled_Returns204()
        {
            //Arrange
            Course course = new Course()
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 3,
            };
            _courseService.UpdateCourseAsync(1, course).Returns(true);

            //Act
            var actionResult = await _controller.PutCourse(1, course) as NoContentResult;

            //Assert
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task PutCourse_WhenCalled_Returns500()
        {
            //Arrange
            Course course = new Course()
            {
                Id = 1,
                CourseName = "國文",
                ProfessorId = 3,
            };
            _courseService.UpdateCourseAsync(1, course).Returns(false);

            //Act
            var actionResult = await _controller.PutCourse(1, course) as ObjectResult;

            //Assert
            Assert.That(actionResult, Is.Not.Null);
            ProblemDetails? problemDetails = actionResult.Value as ProblemDetails;
            Assert.That(problemDetails, Is.Not.Null);
            Assert.That(problemDetails.Status, Is.EqualTo(500));
            Assert.That(problemDetails.Detail, Is.EqualTo("Update Failed"));
        }
    }
}
