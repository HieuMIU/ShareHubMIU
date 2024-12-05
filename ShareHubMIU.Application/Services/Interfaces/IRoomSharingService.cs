using Microsoft.AspNetCore.Hosting;
using ShareHubMIU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Application.Services.Interfaces
{
    public interface IRoomSharingService
    {
        IEnumerable<RoomSharing> GetAllRoomSharings();
        RoomSharing GetItemById(int id);
        void CreateRoomSharing(RoomSharing roomSharing);
        void UpdateRoomSharing(RoomSharing roomSharing);
        bool DeleteRoomSharing(int id);
    }
}
