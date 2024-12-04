using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interface;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Infrastructure.Data;

namespace ShareHubMIU.Infrastructure.Repository
{
    public class CarSharingRepository : Repository<CarSharing>, ICarSharingRepository
    {

        private readonly ApplicationDbContext _db;

        public CarSharingRepository(ApplicationDbContext db) 
            : base(db) 
        {
            _db = db;
        }

        public void Update(CarSharing entity)
        {
            _db.CarSharings.Update(entity);
        }
    }
}
