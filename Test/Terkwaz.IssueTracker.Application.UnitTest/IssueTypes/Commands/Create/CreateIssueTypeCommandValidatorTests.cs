using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create;
using Terkwaz.IssueTracker.Application.UnitTest.Common;
using Xunit;

namespace Terkwaz.IssueTracker.Application.UnitTest.IssueTypes.Commands.Create
{
    public class CreateIssueTypeCommandValidatorTests : CommandTestBase
    {
        private readonly CreateIssueTypeCommandValidators _validator;

        public CreateIssueTypeCommandValidatorTests()
        {
            _validator = new CreateIssueTypeCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(1);
        }

        [Fact]
        public void Given_Name_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Name, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        
    }
}
