using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Update
{
    public class UpdateIssueTypeCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public UpdateIssueTypeCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldUpdateEntriesSuccessfully()
        {
            //Create entity to inserted and update
            var entity = _fixture.Create<IssueType>();

            // Arrange
            var issueType = await ContextOperation.CreateEntity(_context, entity);

            // update properties
            issueType.Name = _fixture.Create<string>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateIssueTypeCommand>(), It.IsAny<IssueType>())).Returns(issueType);

            // creating System Under Test
            var sut = new UpdateIssueTypeCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateIssueTypeCommand(), CancellationToken.None);

            // Assert
            var dbIssueType = _context.IssueTypes.First();
            dbIssueType.Name.ShouldBe(issueType.Name);

        }
    }
}