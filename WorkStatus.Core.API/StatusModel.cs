using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkStatus.Core.API
{
    public class StatusModel
    {
        public long LastCheckedUTCTime { get; set; }
        public long LastUpdatedUTCTime { get; set; }
        public bool IsSuccessed { get; set; }
        public List<CityStatus> citiesStatuses { get; set; }
    }
}
