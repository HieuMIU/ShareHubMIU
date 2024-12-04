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
    public interface ICarSharingService
    {
        IEnumerable<CarSharing> GetAllCarSharings();
        CarSharing GetItemById(int id);
        void CreateCarSharing(CarSharing carSharing);
        void UpdateCarSharing(CarSharing carSharing);
        bool DeleteCarSharing(int id);
    }
}
