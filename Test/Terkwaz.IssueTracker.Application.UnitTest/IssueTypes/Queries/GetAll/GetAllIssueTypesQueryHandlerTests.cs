using AutoFixture;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Dtos;
using Terkwaz.IssueTracker.Application.Features.IssueTypes.Queries.GetAll;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Queries.GetAll
{
    public class GetAllIssueTypesQueryHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetAllIssueTypesQueryHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(List<IssueTypesDto> output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<List<IssueTypesDto>>(It.IsAny<List<IssueType>>())).Returns(output); // AutoMapper setup

            var sut = new GetAllIssueTypesQueryHandler(_context, _mapperMock.Object); // creating system under test

            var temIssueType = _fixture.Create<IssueType>();

            // Act
            await ContextOperation.CreateEntity(_context, temIssueType);

            var result = await sut.Handle(new GetAllIssueTypesQuery(), CancellationToken.None);

            // Assert
            result.Count().ShouldBeGreaterThan(0);
        }
    }
}