using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Issues.Dtos;
using Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Queries
{
    public class GetIssuesByProjectQueryHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetIssuesByProjectQueryHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(List<IssueOutputDto> output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<List<IssueOutputDto>>(It.IsAny<List<Issue>>())).Returns(output); // AutoMapper setup

            var sut = new GetIssuesByProjectQueryHandler(_context, _mapperMock.Object); // creating system under test

            var temProject = _fixture.Create<Project>();
            var temIssue = _fixture.Create<Issue>();

            // Act
            await ContextOperation.CreateEntity(_context, temProject);
            temIssue.ProjectId = temProject.Id;
            await ContextOperation.CreateEntity(_context, temIssue);

            var result = await sut.Handle(new GetIssuesByProjectQuery() { ProjectId = temProject.Id}, CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThan(0);
        }
    }
}
