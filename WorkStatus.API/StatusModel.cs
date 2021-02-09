using System.Collections.Generic;

namespace WorkStatus.API
{
    public class StatusModel
    {
        public long LastCheckedUTCTime { get; set; }
        public long LastUpdatedUTCTime { get; set; }
        public bool IsSuccessed { get; set; }
        public List<CityStatus> citiesStatuses { get; set; }
    }
}