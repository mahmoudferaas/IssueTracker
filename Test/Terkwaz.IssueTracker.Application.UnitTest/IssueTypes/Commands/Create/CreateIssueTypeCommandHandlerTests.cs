using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Create
{
    public class CreateIssueTypeCommandHandlerTests : CommandTestBase
    {
        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(IssueType issueType)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<IssueType>(It.IsAny<CreateIssueTypeCommand>()))
               .Returns(issueType); // AutoMapper setup

            var sut = new CreateIssueTypeCommandHandler(_context, _mapperMock.Object); // creating system under test

            // Act
            await sut.Handle(new CreateIssueTypeCommand(), CancellationToken.None);

            // Assert
            _context.IssueTypes.Count().ShouldBe(1);
        }
    }
}