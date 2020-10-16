using FluentValidation.TestHelper;
using Happy.Domain.Entities;
using Happy.Domain.Validators;
using Happy.Tests.Unit.TestHelpers.Builders.DomainEntitiesBuilders;
using Xunit;

namespace Happy.Tests.Unit.UnitTests.Domain.Extensions.FluentValidation
{
    public class CustomedValidationsTests
    {
        private readonly Orphanage _orphanage;
        private readonly OrphanageValidator _orphanageValidator;

        public CustomedValidationsTests()
        {
            _orphanage = new OrphanageBuilder()
                .GetValidOrphanage();

            _orphanageValidator = new OrphanageValidator();
        }

        [Trait("CustomedValidationTests", "Unit")]
        [Fact]
        public void ValidateLatitude_Must_Call_Extesion_Method()
        {
            _orphanageValidator
                   .ShouldNotHaveValidationErrorFor(entity => entity.Latitude, _orphanage);
        }

        [Trait("CustomedValidationTests", "Unit")]
        [Fact]
        public void ValidateLongitude_Must_Call_Extesion_Method()
        {
            _orphanageValidator
                   .ShouldNotHaveValidationErrorFor(entity => entity.Longitude, _orphanage);
        }
    }
}