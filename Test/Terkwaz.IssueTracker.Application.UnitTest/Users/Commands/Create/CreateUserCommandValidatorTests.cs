using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.Users.Commands.Create
{
    public class CreateUserCommandValidatorTests : CommandTestBase
    {
        private readonly CreateUserCommandValidators _validator;

        public CreateUserCommandValidatorTests()
        {
            _validator = new CreateUserCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(3);
        }

        [Fact]
        public void Given_FullName_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.FullName, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        [Fact]
        public void Given_Email_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Email, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<EmailValidator>()
                .Create());
        }

        [Fact]
        public void Given_Password_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Password, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<MinimumLengthValidator>()
                .Create());
        }
    }
}