using AutoFixture;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;
using Terkwaz.IssueTracker.Application.Features.Users.Queries.GetAll;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Terkwaz.IssueTracker.Domain.Entities;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandlerTests : CommandTestBase
    {
        private readonly IFixture _fixture;

        public GetAllUsersQueryHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Theory]
        [NoRecursion]
        public async Task Handle_GetAllQuery_ShouldReturnEntriesSuccessfully(UserOutput output)
        {
            // Arrange
            _mapperMock.Setup(m => m.Map<UserOutput>(It.IsAny<User>())).Returns(output); // AutoMapper setup

            var sut = new GetAllUsersQueryHandler(_context, _mapperMock.Object); // creating system under test

            var temUser = _fixture.Create<User>();

            // Act
            await ContextOperation.CreateEntity(_context, temUser);

            var result = await sut.Handle(new GetAllUsersQuery(), CancellationToken.None);

            // Assert
            result.Count().ShouldBe(1);
        }
    }
}