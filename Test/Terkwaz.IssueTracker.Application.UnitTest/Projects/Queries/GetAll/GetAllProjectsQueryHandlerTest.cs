using AutoFixture;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Features.Projects.Queries.GetAll;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Projects.Queries.GetAll
{
    public class GetAllProjectsQueryHandlerTest : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetAllProjectsQueryHandlerTest()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(List<ProjectDto> output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<List<ProjectDto>>(It.IsAny<List<Project>>())).Returns(output); // AutoMapper setup

            var sut = new GetAllProjectsQueryHandler(_context, _mapperMock.Object); // creating system under test

            var temProject = _fixture.Create<Project>();

            // Act
            await ContextOperation.CreateEntity(_context, temProject);

            var result = await sut.Handle(new GetAllProjectsQuery(), CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThan(0);
        }
    }
}