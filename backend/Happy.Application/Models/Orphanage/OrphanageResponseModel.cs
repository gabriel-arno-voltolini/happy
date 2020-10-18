namespace Happy.Application.Models.Orphanage
{
    public class OrphanageResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string About { get; set; }
        public string Instructions { get; set; }
        public string OpeningHours { get; set; }
        public bool OpensOnWeekends { get; set; }
    }
}