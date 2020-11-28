using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Issues.Commands.Create
{
    public class CreateIssueCommandValidatorTests : CommandTestBase
    {
        private readonly CreateIssueCommandValidators _validator;

        public CreateIssueCommandValidatorTests()
        {
            _validator = new CreateIssueCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(5);
        }

        //[Fact]
        //public void Given_ProjectId_IsEmpty_When_Validating_Then_Error()
        //{
        //    // Assert
        //    _validator.ShouldHaveRules(x => x.ProjectId, BaseVerifiersSetComposer.Build()
        //        .AddPropertyValidatorVerifier<NotEmptyValidator>()
        //        .AddPropertyValidatorVerifier<NotNullValidator>()
        //        .Create());
        //}

        [Fact]
        public void Given_ReporterId_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.ReporterId, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        [Fact]
        public void Given_IssueTypeId_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.IssueTypeId, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }


        [Fact]
        public void Given_Status_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Status, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .Create());
        }

        [Fact]
        public void Given_Title_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Title, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<NotNullValidator>()
                .AddPropertyValidatorVerifier<LengthValidator>(1,10)
                .Create());
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