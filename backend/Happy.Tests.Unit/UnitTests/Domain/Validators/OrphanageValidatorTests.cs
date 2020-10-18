using FluentValidation.TestHelper;
using Happy.Domain.Validators;
using Happy.Tests.Unit.TestHelpers.Builders.DomainEntitiesBuilders;
using Xunit;

namespace Happy.Tests.Unit.UnitTests.Domain.Validators
{
    public sealed class OrphanageValidatorTests
    {
        private readonly string _oversizedTestStringLength4096;
        private readonly OrphanageValidator _orphanageValidator;

        public OrphanageValidatorTests()
        {
            _orphanageValidator = new OrphanageValidator();
            _oversizedTestStringLength4096 = new string('a', 0x0FFFFFFF + 4096);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Name_Must_Validate_Property()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithName("Happy")
                .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.Name, orphanage);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Name_Must_Not_Validate_Property_When_Oversized()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithName(_oversizedTestStringLength4096)
                .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.Name, orphanage)
                .WithErrorMessage("Name length must be between 0 and 128 chars");
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void About_Must_Validate_Property()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithAbout("Happy")
                .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.About, orphanage);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void About_Must_Not_Validate_Property_When_Oversized()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithAbout(_oversizedTestStringLength4096)
                .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.About, orphanage)
                .WithErrorMessage("About length must be between 0 and 2048 chars");
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Instructions_Must_Validate_Property()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithInstructions("Happy")
                .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.Instructions, orphanage);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Instructions_Must_Not_Validate_Property_When_Oversized()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithInstructions(_oversizedTestStringLength4096)
                .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.Instructions, orphanage)
                .WithErrorMessage("Instructions length must be between 0 and 2048 chars");
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void OpeningHours_Must_Validate_Property()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                   .WithOpeningHours("10am - 12pm")
                   .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.OpeningHours, orphanage);

        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void OpeningHours_Must_Not_Validate_Property_When_Oversized()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                   .WithOpeningHours(_oversizedTestStringLength4096)
                   .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.OpeningHours, orphanage)
                .WithErrorMessage("Opening hours length must be between 0 and 64 chars");
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Latitude_Must_Validate_Property()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithLatitude(56.66922)
                .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.Latitude, orphanage);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Latitude_Must_Not_Validate_Property_Latitude_When_Invalid()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
              .WithLatitude(90.34311)
              .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.Latitude, orphanage)
                .WithErrorMessage("Invalid Latitude");
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Longitude_Must_Validate_Property_Longitude()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
                .WithLongitude(122.66922)
                .Build();

            //Assert
            _orphanageValidator
                .ShouldNotHaveValidationErrorFor(entity => entity.Longitude, orphanage);
        }

        [Trait("OrphanageValidatorTests", "Unit")]
        [Fact]
        public void Longitude_Must_Not_Validate_Property_Longitude_When_Invalid()
        {
            //Arrange
            var orphanage = new OrphanageBuilder()
              .WithLongitude(180.22121)
              .Build();

            //Assert
            _orphanageValidator
                .ShouldHaveValidationErrorFor(entity => entity.Longitude, orphanage)
                .WithErrorMessage("Invalid Longitude");
        }
    }
}