using AutoFixture;
using MediatR;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create;
using Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Projects.Commands.Create
{
    public class CreateProjectCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;
        protected readonly Mock<IMediator> _mediatorMock;

        public CreateProjectCommandHandlerTests()
        {
            _fixture = new Fixture();
            _mediatorMock = new Mock<IMediator>();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_ValidCommand_ShouldSaveEntriesSuccessfully(Project Project)
        {
            _fixture.RepeatCount = 0;
            // Arrange
            _mapperMock.Setup(m => m.Map<Project>(It.IsAny<CreateProjectCommand>())).Returns(Project); // AutoMapper setup

            _mediatorMock.Setup(m => m.Publish(It.IsAny<CreateProjectParticipantsCommand>(), It.IsAny<CancellationToken>()));

            var sut = new CreateProjectCommandHandler(_context, _mapperMock.Object, _mediatorMock.Object); // creating system under test

            // Act
            var owner = _fixture.Create<User>();
            await ContextOperation.CreateEntity(_context, owner);

            await sut.Handle(new CreateProjectCommand { OwnerId = owner.Id }, CancellationToken.None);

            // Assert
            _context.Projects.Count().ShouldBe(1);
        }
    }
}