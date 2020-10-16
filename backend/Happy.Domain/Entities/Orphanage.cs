using Happy.Domain.Interfaces.Entities;
using Happy.Domain.Validators;

namespace Happy.Domain.Entities
{
    public class Orphanage : BaseEntity, IOrphanage
    {
        public string Name { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public string About { get; protected set; }
        public string Instructions { get; protected set; }
        public bool OpensOnWeekends { get; protected set; }

        public Orphanage(string name, double latitude, double longitude)
            : base(new OrphanageValidator())
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Orphanage(string name, double latitude, double longitude,
            string about, string instructions, bool opensOnWeekends)
            : this(name, latitude, longitude)
        {
            About = about;
            Instructions = instructions;
            OpensOnWeekends = opensOnWeekends;
        }

        protected Orphanage() : base(new OrphanageValidator())
        {
        }

        public void Update(string name, double latitude, double longitude)
        {
            Update();
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Update(string about, string instructions, bool opensOnWeekends)
        {
            Update();
            About = about;
            Instructions = instructions;
            OpensOnWeekends = opensOnWeekends;
        }
    }
}