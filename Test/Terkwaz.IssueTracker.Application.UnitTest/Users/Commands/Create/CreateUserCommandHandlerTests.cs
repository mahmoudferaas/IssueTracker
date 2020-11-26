using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Users.Commands.Create
{
    public class CreateUserCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(User User)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<User>(It.IsAny<CreateUserCommand>()))
               .Returns(User); // AutoMapper setup

            var sut = new CreateUserCommandHandler(_context, _mapperMock.Object); // creating system under test

            // Act
            await sut.Handle(new CreateUserCommand(), CancellationToken.None);

            // Assert
            _context.Users.Count().ShouldBe(1);
        }
    }
}