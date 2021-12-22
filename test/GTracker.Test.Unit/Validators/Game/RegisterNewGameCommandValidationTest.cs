using FluentAssertions;
using GTracker.Domain.Validation.Game;
using GTracker.Domain.Commands.Game;
using System;
using Xunit;

namespace GTracker.Test.Unit.Validators.Game
{
    public class RegisterNewGameCommandValidationTest
    {
        [Theory]
        [InlineData("Lucas", "2020-03-01", 1, "", true)]        
        [InlineData(null, "2020-06-08", 1, "", false)]
        public void GivenGameWhenRegisterThenExpectedValue(string name, string acquisicionDate, int kind, string observation, bool expectedResult)
        {   
            // Arrange
            var date = DateTime.Parse(acquisicionDate);
            var validator = new RegisterNewGameCommandValidation();
            var gameCommand = new RegisterNewGameCommand
            {   
                Name = name,
                AcquisicionDate = date,
                Kind = kind,
                Observation = observation
            };

            // Act
            var result = validator.Validate(gameCommand);

            // Assert
            result.IsValid.Should().Be(expectedResult);
        }
    }
}