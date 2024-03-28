using AutoFixture;
using FluentValidation.TestHelper;
using SolarLab.Academy.AppServices.Validators;
using SolarLab.Academy.Contracts.Users;

namespace SolarlLab.Academy.UnitTests
{
    public class CreateUserValidatorTests
    {
        [Fact]
        public void ShouldError_BirthDateNull()
        {
            // Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateUserRequest>()
                .With(x => x.FirstName, "FirstName")
                .With(x => x.LastName, "LastName")
                .With(x => x.MiddleName, "MiddleName")
                .With(x => x.Region, 10)
                .With(x => x.BirthDate, (DateTime?)null)
                .Create();
            var sut = new CreateUserValidator();

            // Act
            var result = sut.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.BirthDate)
                .Only();
        }

        [Theory]
        [InlineData("")]
        [InlineData("012345678901234567890123456789012345678901234567891")]
        [InlineData("0123456789")]
        [InlineData("FirstName1")]
        public void ShouldError_FirstNameIncorrect(string testString)
        {
            // Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateUserRequest>()
                .With(x => x.FirstName, testString)
                .With(x => x.LastName, "LastName")
                .With(x => x.MiddleName, "MiddleName")
                .With(x => x.Region, 10)
                .With(x => x.BirthDate, DateTime.Now.Date.AddYears(-19))
                .Create();
            var sut = new CreateUserValidator();

            // Act
            var result = sut.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName)
                .Only();
        }

        [Theory]
        [InlineData("FirstName")]
        [InlineData("Алексей")]
        public void ShouldCorrect_FirstName(string testString)
        {
            // Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateUserRequest>()
                .With(x => x.FirstName, testString)
                .With(x => x.LastName, "LastName")
                .With(x => x.MiddleName, "MiddleName")
                .With(x => x.Region, 10)
                .With(x => x.BirthDate, DateTime.Now.Date.AddYears(-19))
                .Create();
            var sut = new CreateUserValidator();

            // Act
            var result = sut.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }
    }
}