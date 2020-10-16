namespace Happy.Domain.Interfaces.Entities
{
    internal interface IOrphanage
    {
        void Update(string name, decimal latitude, decimal longitude);

        void Update(string about, string instructions, bool opensOnWeekends);
    }
}