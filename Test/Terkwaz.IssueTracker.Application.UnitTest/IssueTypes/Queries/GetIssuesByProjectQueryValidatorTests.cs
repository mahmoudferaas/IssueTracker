using AutoFixture;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Features.Issues.Queries.GetIssuesByProject;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Queries
{
    public class GetIssuesByProjectQueryValidatorTests : CommandTestBase
    {
        private readonly GetIssuesByProjectQueryValidators _validator;

        public GetIssuesByProjectQueryValidatorTests()
        {
            _validator = new GetIssuesByProjectQueryValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(1);
        }

        [Fact]
        public void Given_ProjectId_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.ProjectId, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        

    }
}