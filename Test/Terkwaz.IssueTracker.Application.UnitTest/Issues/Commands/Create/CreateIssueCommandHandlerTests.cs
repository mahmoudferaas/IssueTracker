using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Issues.Commands.Create
{
    public class CreateIssueCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public CreateIssueCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(Domain.Entities.Issue Issue)
        {
            _fixture.RepeatCount = 0;
            // Arrange
            _mapperMock.Setup(m => m.Map<Domain.Entities.Issue>(It.IsAny<CreateIssueCommand>()))
               .Returns(Issue); // AutoMapper setup

            var sut = new CreateIssueCommandHandler(_context, _mapperMock.Object); // creating system under test

            var project = await ContextOperation.CreateEntity(_context, _fixture.Create<Project>());
            // Act
            await sut.Handle(new CreateIssueCommand { ProjectId = project.Id}, CancellationToken.None);

            // Assert
            _context.Issues.Count().ShouldBe(1);
        }
    }
}