using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Update
{
    public class UpdateIssueTypeCommandValidatorTests : CommandTestBase
    {
        private readonly UpdateIssueTypeCommandValidators _validator;

        public UpdateIssueTypeCommandValidatorTests()
        {
            _validator = new UpdateIssueTypeCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(2);
        }

        [Fact]
        public void Given_Name_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Name, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
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