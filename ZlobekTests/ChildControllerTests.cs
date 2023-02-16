using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using zlobek.Controllers;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Tests.Controllers
{
    public class ChildControllerTests
    {
        private readonly Mock<IChildService> _childServiceMock;
        private readonly ChildController _childController;

        public ChildControllerTests()
        {
            _childServiceMock = new Mock<IChildService>();
            _childController = new ChildController(_childServiceMock.Object);
        }

        [Fact]
        public async Task Create_ValidChild_CreatesAndReturnsViewWithModel()
        {
            // Arrange
            var child = new Child { Name = "John", Surname = "Doe", GroupId = 1 };
            _childServiceMock.Setup(x => x.CreateChild(child)).Returns(Task.FromResult(child));

            // Act
            var result = await _childController.Create(child) as ViewResult;

            // Assert
            _childServiceMock.Verify(x => x.CreateChild(child), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(child, result.Model);
        }


        [Fact]
        public async Task Edit_ValidChild_UpdatesAndReturnsViewWithModel()
        {
            // Arrange
            var child = new Child { ChildID = 1, Name = "John", Surname = "Doe", GroupId = 1 };
            _childServiceMock.Setup(x => x.UpdateChild(child.ChildID, child)).Returns(Task.FromResult(true));

            _childController.ControllerContext = new ControllerContext();
            _childController.ControllerContext.HttpContext = new DefaultHttpContext();
            _childController.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>
    {
        { "ChildId", child.ChildID.ToString() }
    });

            // Act
            var result = await _childController.Edit(child) as ViewResult;

            // Assert
            _childServiceMock.Verify(x => x.UpdateChild(child.ChildID, child), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(child, result.Model);
        }


    }
}
