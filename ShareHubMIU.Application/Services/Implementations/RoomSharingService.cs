using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Application.Services.Implementations
{
    public class RoomSharingService : IRoomSharingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomSharingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRoomSharing(RoomSharing roomSharing)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoomSharing(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomSharing> GetAllRoomSharings()
        {
            throw new NotImplementedException();
        }

        public RoomSharing GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoomSharing(RoomSharing RoomSharing)
        {
            throw new NotImplementedException();
        }
    }
}
