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
    public class CarSharingService : ICarSharingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarSharingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCarSharing(CarSharing carSharing)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCarSharing(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarSharing> GetAllCarSharings()
        {
            throw new NotImplementedException();
        }

        public CarSharing GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCarSharing(CarSharing carSharing)
        {
            throw new NotImplementedException();
        }
    }
}
