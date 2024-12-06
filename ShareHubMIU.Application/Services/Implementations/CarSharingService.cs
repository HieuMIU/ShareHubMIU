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
            ArgumentNullException.ThrowIfNull(carSharing);

            //set default value
            carSharing.DateListed = DateTime.Now;

            _unitOfWork.CarSharing.Add(carSharing);
            _unitOfWork.Save();
        }

        public bool DeleteCarSharing(int id)
        {
            try
            {
                CarSharing? objFromDb = _unitOfWork.CarSharing.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.CarSharing.Remove(objFromDb);
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

        public IEnumerable<CarSharing> GetAllCarSharings()
        {
            return _unitOfWork.CarSharing.GetAll();
        }

        public CarSharing GetItemById(int id)
        {
            return _unitOfWork.CarSharing.Get(u => u.Id == id);
        }

        public void UpdateCarSharing(CarSharing carSharing)
        {
            _unitOfWork.CarSharing.Update(carSharing);
            _unitOfWork.Save();
        }
    }
}
