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
    public class RequestRepository : Repository<Request>, IRequestRepository
    {

        private readonly ApplicationDbContext _db;

        public RequestRepository(ApplicationDbContext db) 
            : base(db) 
        {
            _db = db;
        }

        public void Update(Request entity)
        {
            _db.Requests.Update(entity);
        }
    }
}
