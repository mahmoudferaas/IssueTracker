using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Delete;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Issues.Commands.Delete
{
    public class DeleteIssueCommandValidatorTests : CommandTestBase
    {
        private readonly DeleteIssueCommandValidators _validator;

        public DeleteIssueCommandValidatorTests()
        {
            _validator = new DeleteIssueCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(1);
        }

        [Fact]
        public void Given_Id_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Id, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }
    }
}