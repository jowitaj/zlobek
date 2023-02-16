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

namespace zlobek.Tests
{
    public class MenuControllerTests
    {
        [Fact]
        public async Task Create_ValidMenu_ReturnsViewWithMenu()
        {
            // Arrange
            var mockMenuService = new Mock<IMenuService>();
            var menuController = new MenuController(mockMenuService.Object);
            var menu = new Menu { Allergens = "anything" };

            // Act
            var result = await menuController.Create(menu) as ViewResult;

            // Assert
            mockMenuService.Verify(x => x.CreateMenu(menu), Times.Once);
            Assert.Equal(menu, result.Model);
        }

        [Fact]


        public async Task Edit_ValidMenu_UpdatesAndReturnsViewWithModel()
        {
            var mockMenuService = new Mock<IMenuService>();
            var menuController = new MenuController(mockMenuService.Object);
            // Arrange
            var menu = new Menu { MenuId = 1, Allergens = "Menu 1 description" };
            mockMenuService.Setup(x => x.UpdateMenu(menu.MenuId, menu))
                .Returns(Task.FromResult(true));
            menuController.ControllerContext.HttpContext = new DefaultHttpContext();
            menuController.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>()
    {
        { "menuId", menu.MenuId.ToString() }
    });

            // Act
            var result = await menuController.Edit(menu) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(menu, result.Model);
            mockMenuService.Verify(x => x.UpdateMenu(menu.MenuId, menu), Times.Once);
        }



    }
}
