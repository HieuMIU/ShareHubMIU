using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interface;

namespace ShareHubMIU.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICarSharingRepository CarSharing { get; }

        IRoomSharingRepository RoomSharing { get; }

        ICommonItemRepository CommonItem { get; }

        IApplicationUserRepository User { get; }

        IItemRepository Item { get; }

        void Save();
    }
}
