using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkStatus.Core.API
{
    public class CityStatus
    {
        public string CityNameEn { get; set; }
        public string CityNameCh { get; set; }
        public int IsCanceled { get; set; }
        public Dictionary<string, string> Notes { get; set; }
    }
}
