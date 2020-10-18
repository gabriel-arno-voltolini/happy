namespace Happy.Domain.Interfaces.Entities
{
    internal interface IOrphanage
    {
        void Update(string name, double latitude, double longitude);

        void Update(string about, string instructions, string openingHours, bool opensOnWeekends);
    }
}