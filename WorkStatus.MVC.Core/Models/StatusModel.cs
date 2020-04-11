namespace WorkStatus.MVC.Core.Models
{
    public class StatusModel
    {
        public int lastCheckedUTCTime { get; set; }
        public int lastUpdatedUTCTime { get; set; }
        public bool isSuccessed { get; set; }
        public Citiesstatus[] citiesStatuses { get; set; }
    }

    public class Citiesstatus
    {
        public string cityNameEn { get; set; }
        public string cityNameCh { get; set; }
        public bool isCanceled { get; set; }
        public string[] notes { get; set; }
    }

}
