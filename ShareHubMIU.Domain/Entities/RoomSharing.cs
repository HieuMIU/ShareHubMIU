using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Domain.Entities
{
    public class RoomSharing : Item
    {
        public int Capacity { get; set; }
        public string RoomType { get; set; } // e.g., Single, Shared
        public bool IsFurnished { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableUntil { get; set; }
    }

}
