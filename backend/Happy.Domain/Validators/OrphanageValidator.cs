using FluentValidation;
using Happy.Domain.Entities;
using Happy.Domain.Extensions.FluentValidation;

namespace Happy.Domain.Validators
{
    public class OrphanageValidator : AbstractValidator<Orphanage>
    {
        public OrphanageValidator()
        {
            RuleFor(c => c.Name)
                .Length(0, 128)
                .WithMessage("Name length must be between 0 and 128 chars");

            RuleFor(c => c.About)
                 .Length(0, 2048)
                 .WithMessage("About length must be between 0 and 2048 chars");

            RuleFor(c => c.Instructions)
                 .Length(0, 2048)
                 .WithMessage("Instructions length must be between 0 and 2048 chars");

            RuleFor(c => c.Latitude)
                .ValidateLatitude()
                .WithMessage("Invalid Latitude");

            RuleFor(c => c.Longitude)
               .ValidateLongitude()
               .WithMessage("Invalid Longitude");
        }
    }
}