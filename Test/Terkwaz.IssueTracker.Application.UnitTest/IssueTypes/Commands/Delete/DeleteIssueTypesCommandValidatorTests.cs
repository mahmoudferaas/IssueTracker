using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Features.IssueTypes.Commands.Delete;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Delete
{
    public class DeleteIssueTypesCommandValidatorTests : CommandTestBase
    {
        private readonly DeleteIssueTypesCommandValidators _validator;

        public DeleteIssueTypesCommandValidatorTests()
        {
            _validator = new DeleteIssueTypesCommandValidators();
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