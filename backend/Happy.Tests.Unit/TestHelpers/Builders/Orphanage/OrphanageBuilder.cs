using Happy.Domain.Entities;

namespace Happy.Tests.Unit.TestHelpers.Builders.DomainEntitiesBuilders
{
    public class OrphanageBuilder
    {
        private string _name;
        private double _latitude;
        private double _longitude;
        private string _about;
        private string _instructions;
        private string _openingHours;
        private bool _opensOnWeekends;

        public OrphanageBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public OrphanageBuilder WithLatitude(double latitude)
        {
            _latitude = latitude;
            return this;
        }

        public OrphanageBuilder WithLongitude(double longitude)
        {
            _longitude = longitude;
            return this;
        }

        public OrphanageBuilder WithAbout(string about)
        {
            _about = about;
            return this;
        }

        public OrphanageBuilder WithInstructions(string instructions)
        {
            _instructions = instructions;
            return this;
        }

        public OrphanageBuilder WithOpeningHours(string openingHours)
        {
            _openingHours = openingHours;
            return this;
        }

        public OrphanageBuilder WithOpensOnWeekends(bool openOnWeekends)
        {
            _opensOnWeekends = openOnWeekends;
            return this;
        }

        public Orphanage Build()
        {
            return new Orphanage
                (
                _name,
                _latitude,
                _longitude,
                _about,
                _instructions,
                _openingHours,
                _opensOnWeekends
                );
        }

        public Orphanage GetValidOrphanage() 
        {
            return new OrphanageBuilder()
                 .WithName("Happy")
                 .WithLatitude(-26.8126418)
                 .WithLongitude(-49.2668968)
                 .WithAbout("Our missions is to improve mankind")
                 .WithInstructions("Contact us for visiting")
                 .WithOpeningHours("10am - 3pm")
                 .WithOpensOnWeekends(true)
                 .Build();
        }

        public Orphanage GeInvalidOrphanage()
        {
            return new OrphanageBuilder()
                 .WithName(null)
                 .WithLatitude(-00)
                 .WithLongitude(-00)
                 .WithAbout("")
                 .WithInstructions("                  ")
                 .WithOpeningHours(null)
                 .WithOpensOnWeekends(false)
                 .Build();
        }
    }
}