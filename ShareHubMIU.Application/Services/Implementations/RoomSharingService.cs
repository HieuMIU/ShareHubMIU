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
            ArgumentNullException.ThrowIfNull(roomSharing);

            //set default value
            roomSharing.DateListed = DateTime.Now;

            _unitOfWork.RoomSharing.Add(roomSharing);
            _unitOfWork.Save();
        }

        public bool DeleteRoomSharing(int id)
        {
            try
            {
                RoomSharing? objFromDb = _unitOfWork.RoomSharing.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.RoomSharing.Remove(objFromDb);
                    _unitOfWork.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<RoomSharing> GetAllRoomSharings()
        {
            return _unitOfWork.RoomSharing.GetAll();
        }

        public RoomSharing GetItemById(int id)
        {
            return _unitOfWork.RoomSharing.Get(u => u.Id == id);
        }

        public void UpdateRoomSharing(RoomSharing roomSharing)
        {
            _unitOfWork.RoomSharing.Update(roomSharing);
            _unitOfWork.Save();
        }
    }
}
