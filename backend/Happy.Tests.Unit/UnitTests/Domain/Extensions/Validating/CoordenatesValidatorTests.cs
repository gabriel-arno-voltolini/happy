using FluentAssertions;
using Happy.Domain.Extensions.Validating;
using Xunit;

namespace Happy.Tests.Unit.UnitTests.Domain.Extensions.Validating
{
    public class CoordenatesValidatorTests
    {
        [Trait("CoordenatesValitatorTest", "Unit")]
        [Theory]
        [InlineData(-85.05112878)]
        [InlineData(55.05112878)]
        [InlineData(5.05114878)]
        [InlineData(-89.05112878)]
        [InlineData(90)]
        [InlineData(-90)]
        [InlineData(0)]
        public void Must_Validate_Coordenate_Latitude(double latitude)
        {
            //Act
            var result = latitude.ValidateLatitude();

            //Assert
            result.Should().BeTrue();
        }

        [Trait("CoordenatesValitatorTest", "Unit")]
        [Theory]
        [InlineData(-385.05112878)]
        [InlineData(255.05112878)]
        [InlineData(335.05114878)]
        [InlineData(-589.05112878)]
        [InlineData(990)]
        [InlineData(-890)]
        public void Must_Not_Validate_Coordenate_Latitude(double latitude)
        {
            //Act
            var result = latitude.ValidateLatitude();

            //Assert
            result.Should().BeFalse();
        }

        [Trait("CoordenatesValitatorTest", "Unit")]
        [Theory]
        [InlineData(-85.05112878)]
        [InlineData(55.05112878)]
        [InlineData(5.05114878)]
        [InlineData(-89.05112878)]
        [InlineData(180)]
        [InlineData(-180)]
        [InlineData(0)]
        public void Must_Validate_Coordenate_Longitude(double longitude)
        {
            //Act
            var result = longitude.ValidateLongitude();

            //Assert
            result.Should().BeTrue();
        }

        [Trait("CoordenatesValitatorTest", "Unit")]
        [Theory]
        [InlineData(-385.05112878)]
        [InlineData(255.05112878)]
        [InlineData(335.05114878)]
        [InlineData(-589.05112878)]
        [InlineData(990)]
        [InlineData(-890)]
        public void Must_Not_Validate_Coordenate_Longitude(double longitude)
        {
            //Act
            var result = longitude.ValidateLongitude();

            //Assert
            result.Should().BeFalse();
        }
    }
}