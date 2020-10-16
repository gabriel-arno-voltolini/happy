using System;

namespace Happy.Domain.Extensions.Validating
{
    public static class CoordenatesValidator
    {
        public static bool ValidateLatitude(this double latitude)
        {
            return Math.Abs(latitude) <= 90;
        }

        public static bool ValidateLongitude(this double longitude)
        {
            return Math.Abs(longitude) <= 180;
        }
    }
}
