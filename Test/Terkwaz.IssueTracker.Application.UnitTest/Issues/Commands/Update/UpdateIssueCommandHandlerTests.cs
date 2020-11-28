using AutoFixture;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Update;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Issues.Commands.Update
{
    public class UpdateIssueCommandHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public UpdateIssueCommandHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [Fact]
        public async Task Handle_ValidCommand_ShouldUpdateEntriesSuccessfully()
        {
            //Create entity to inserted and update
            var entity = _fixture.Create<Domain.Entities.Issue>();

            // Arrange
            var issue = await ContextOperation.CreateEntity(_context, entity);

            // update properties
            issue.Title = _fixture.Create<string>();

            // AutoMapper setup
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateIssueCommand>(), It.IsAny<Domain.Entities.Issue>())).Returns(issue);

            // creating System Under Test
            var sut = new UpdateIssueCommandHandler(_context, _mapperMock.Object);

            // Act
            await sut.Handle(new UpdateIssueCommand(), CancellationToken.None);

            // Assert
            var dbIssue = _context.Issues.First();
            dbIssue.Title.ShouldBe(issue.Title);

        }
    }
}