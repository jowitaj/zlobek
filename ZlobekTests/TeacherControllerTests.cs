using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using Xunit;
using zlobek.Controllers;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Tests
{
    public class TeacherControllerTests
    {
        private readonly Mock<ITeacherService> _mockTeacherService;
        private readonly TeacherController _teacherController;

        public TeacherControllerTests()
        {
            _mockTeacherService = new Mock<ITeacherService>();
            _teacherController = new TeacherController(_mockTeacherService.Object);
        }

        [Fact]
        public async Task Create_ValidModel_ReturnsViewWithModel()
        {

            // Arrange
            var teacher = new Teacher

            {
                Name = "Jan",
                Surname = "Kowalski"
            };
            _mockTeacherService.Setup(service => service.CreateTeacher(It.IsAny<Teacher>()))
    .Returns(Task.FromResult(teacher));

            

            // Act
            var result = await _teacherController.Create(teacher);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Teacher>(viewResult.Model);
            Assert.Equal(teacher.Name, model.Name);
            Assert.Equal(teacher.Surname, model.Surname);
        }

        [Fact]
        public async Task Create_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var teacher = new Teacher();
            _teacherController.ModelState.AddModelError("error", "some error");

            // Act
            var result = await _teacherController.Create(teacher);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Edit_ValidModel_ReturnsViewWithModel()
        {
            // Arrange
            var teacher = new Teacher
            {
                TeacherID = 1,
                Name = "Jan",
                Surname = "Kowalski"
            };

            _mockTeacherService.Setup(service => service.CreateTeacher(It.IsAny<Teacher>()))
        .Returns(Task.FromResult(teacher));

            _teacherController.ControllerContext = new ControllerContext();
            _teacherController.ControllerContext.HttpContext = new DefaultHttpContext();
            _teacherController.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>()
    {
        { "TeacherId", teacher.TeacherID.ToString() }
    });

            // Act
            var result = await _teacherController.Edit(teacher);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Teacher>(viewResult.Model);
            Assert.Equal(teacher.Name, model.Name);
            Assert.Equal(teacher.Surname, model.Surname);
        }

        [Fact]
        public async Task Edit_InvalidModel_ReturnsBadRequest()
        { 
            var teacher = new Teacher { TeacherID = 1, Name = "John", Surname = "Doe" };
            _mockTeacherService.Setup(x => x.UpdateTeacher(teacher.TeacherID, teacher))
                .Returns(Task.FromResult(true));
            _teacherController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            _teacherController.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>()
{
    { "TeacherId","1"  }
});
            // Act
            var result = await _teacherController.Edit(teacher) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(teacher, result.Model);
            _mockTeacherService.Verify(x => x.UpdateTeacher(teacher.TeacherID, teacher), Times.Once);

        }

    }
}
