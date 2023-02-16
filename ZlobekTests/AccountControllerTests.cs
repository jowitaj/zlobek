using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Primitives;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using zlobek.Controllers;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _accountServiceMock;
        private readonly Mock<IPasswordHasher<Account>> _passwordHasherMock;
        private readonly AccountController _accountController;

        public AccountControllerTests()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _passwordHasherMock = new Mock<IPasswordHasher<Account>>();
            _accountController = new AccountController(_accountServiceMock.Object, _passwordHasherMock.Object);
        }

        [Fact]
        public async Task Create_ValidAccount_CreatesAndReturnsViewWithModel()
        {
            // Arrange
            var account = new Account { Email = "valid-email@example.com", Password = "password", RoleId = 1 };
            _accountServiceMock.Setup(x => x.CreateAccount(account))
                               .Returns(Task.FromResult(account));

            // Act
            var result = await _accountController.Create(account) as ViewResult;

            // Assert
            _accountServiceMock.Verify(x => x.CreateAccount(account), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(account, result.Model);
        }


        [Fact]
        public async Task Edit_ValidAccount_UpdatesAndReturnsViewWithModel()
        {
            // Arrange
            var account = new Account { Email = "valid-email@example.com", Password = "password", RoleId = 1 };
            _accountServiceMock.Setup(x => x.UpdateAccount(account.AccountId, account))
                .Returns(Task.FromResult(true));

            _accountController.ControllerContext = new ControllerContext();
            _accountController.ControllerContext.HttpContext = new DefaultHttpContext();
            _accountController.ControllerContext.HttpContext.Request.Form = new FormCollection(new Dictionary<string, StringValues>
    {
        { "AccountId", account.AccountId.ToString() }
    });

            // Act
            var result = await _accountController.Edit(account) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(account, result.Model);
            _accountServiceMock.Verify(x => x.UpdateAccount(account.AccountId, account), Times.Once);
        }




    }
}


