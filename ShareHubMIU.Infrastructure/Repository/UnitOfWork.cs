using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interface;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Infrastructure.Data;

namespace ShareHubMIU.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IApplicationUserRepository User { get; private set; }

        public ICarSharingRepository CarSharing { get; private set; }

        public IRoomSharingRepository RoomSharing { get; private set; }

        public ICommonItemRepository CommonItem { get; private set; }

        public IItemRepository Item { get; private set; }

        public IRequestRepository Request { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CarSharing = new CarSharingRepository(db);
            RoomSharing = new RoomSharingRepository(db);
            CommonItem = new CommonItemRepository(db);
            User = new ApplicationUserRepository(_db);
            Item = new ItemRepository(_db);
            Request = new RequestRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
