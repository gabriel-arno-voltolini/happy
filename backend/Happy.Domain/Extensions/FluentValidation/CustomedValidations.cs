using FluentValidation;
using Happy.Domain.Extensions.Validating;

namespace Happy.Domain.Extensions.FluentValidation
{
    public static class CustomedValidations
    {
        public static IRuleBuilderOptions<T, double> ValidateLatitude<T>(this IRuleBuilder<T, double> ruleBuilder) =>
            ruleBuilder.Must(c => c.ValidateLatitude());

        public static IRuleBuilderOptions<T, double> ValidateLongitude<T>(this IRuleBuilder<T, double> ruleBuilder) =>
          ruleBuilder.Must(c => c.ValidateLongitude());
    }
}