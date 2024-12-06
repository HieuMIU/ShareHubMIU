using ShareHubMIU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Application.Common.Interface
{
    public interface IRequestRepository : IRepository<Request>
    {
        void Update(Request entity);
    }
}
