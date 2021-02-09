using System.Collections.Generic;

namespace WorkStatus.API
{
    public class CityStatus
    {
        public string CityNameEn { get; set; }
        public string CityNameCh { get; set; }
        public bool IsCanceled { get; set; }
        public List<string> Notes { get; set; }
    }
}