using AutoFixture;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common;
using Terkwaz.IssueTracker.Application.Common.Exceptions;
using Terkwaz.IssueTracker.Application.Common.Helpers;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Login;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Users.Commands.Login
{
    public class LoginCommandHandlerTests : CommandTestBase
    {
        private readonly Mock<IOptions<AppSettings>> _appsettingMock;
        private readonly IFixture _fixture;

        public LoginCommandHandlerTests()
        {
            _fixture = new Fixture();
            _appsettingMock = new Mock<IOptions<AppSettings>>();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldLoginSuccessfully(LoginOutput loginOutput)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<LoginOutput>(It.IsAny<User>())).Returns(loginOutput); // AutoMapper setup

            _appsettingMock.SetReturnsDefault(new AppSettings
            {
                Issuer = "key1",
                Secret = "kesdfaaaaaasffffffffy1"
            });

            var sut = new LoginCommandHandler(_context, _mapperMock.Object, _appsettingMock.Object); // creating system under test

            var temUser = _fixture.Create<User>();

            temUser.PasswordHash = "3pRTT3NlZJrki0wrSlmOjA==";

            // Act
            await ContextOperation.CreateEntity(_context, temUser);

            var password = SecurityHelper.Decrypt(temUser.PasswordHash);

            var output = await sut.Handle(new LoginCommand { Email = temUser.Email, Password = password }, CancellationToken.None);

            // Assert
            Assert.True(!string.IsNullOrEmpty(output.Token));

        }

        [Theory]
        [NoRecursion]
        public async Task Handle_InValidCommand_ShouldLoginWithError(LoginOutput loginOutput)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<LoginOutput>(It.IsAny<User>())).Returns(loginOutput); // AutoMapper setup

            _appsettingMock.SetReturnsDefault(new AppSettings
            {
                Issuer = "key1",
                Secret = "kesdfaaaaaasffffffffy1"
            });

            var sut = new LoginCommandHandler(_context, _mapperMock.Object, _appsettingMock.Object); // creating system under test

            var temUser = _fixture.Create<User>();

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new LoginCommand { Email = _fixture.Create<string>(), Password = _fixture.Create<string>() }, CancellationToken.None));

        }
    }
}