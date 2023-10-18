using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    public class LastSyncDateTime : Entity
    {
        public DateTime LastSyncTime { get; set; }
        public LastSyncDateTime(DateTime? lastSyncDateTime)
        {
            if (lastSyncDateTime.HasValue)
                LastSyncTime = lastSyncDateTime.Value;
        }
    }
}
