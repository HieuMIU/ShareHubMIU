using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.DTOs;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Application.Common.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";

        public const string CategoryTypeCarSharing = "CarSharing";
        public const string CategoryTypeRoomSharing = "RoomSharing";
        public const string CategoryTypeFuniture = "Funiture";
        public const string CategoryTypeElectronics = "Electronics";
        public const string CategoryTypeMiscellaneous = "Miscellaneous";

        public const string ConditionNew = "New";
        public const string ConditionUsedLikeNew = "UsedLikeNew";
        public const string ConditionUsedGood = "UsedGood";
        public const string ConditionUsedFair = "UsedFair";

        public const string RoomTypeSingle = "Single";
        public const string RoomTypeShared = "Shared";

        public const string ItemStatusAvailable = "Available";
        public const string ItemStatusReserved = "Reserved";
        public const string ItemStatusSold = "Sold";
        public const string ItemStatusCancelled = "Cancelled";

    }
}
