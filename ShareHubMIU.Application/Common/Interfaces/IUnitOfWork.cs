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
        IItemRepository Item { get; }

        IApplicationUserRepository User { get; }    

        void Save();
    }
}
