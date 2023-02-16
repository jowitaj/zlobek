using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Moq;
using zlobek.Controllers;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Tests.Controllers
{
    public class GroupControllerTests
    {
        private readonly Mock<IGroupService> _groupServiceMock;
        private readonly GroupController _groupController;

        public GroupControllerTests()
        {
            _groupServiceMock = new Mock<IGroupService>();
            _groupController = new GroupController(_groupServiceMock.Object);
        }

        [Fact]
        public async Task Create_ValidGroup_CreatesAndReturnsViewWithModel()
        {
            // Arrange
            var group = new Groups { Name = "TestGroup" };
            _groupServiceMock.Setup(x => x.CreateGroups(group)).Returns(Task.FromResult(group));

            // Act
            var result = await _groupController.Create(group) as ViewResult;

            // Assert
            _groupServiceMock.Verify(x => x.CreateGroups(group), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(group, result.Model);
        }


    }
}
