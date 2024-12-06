using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;

namespace ShareHubMIU.Application.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRequest(Request request)
        {
            ArgumentNullException.ThrowIfNull(request);

            //set default value
            request.CreatedDate = DateTime.Now;
            request.Status = SD.RequestStatusNew.ToString();

            _unitOfWork.Request.Add(request);
            _unitOfWork.Save();
        }

        public bool DeleteRequest(int id)
        {
            try
            {
                Request? objFromDb = _unitOfWork.Request.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Request.Remove(objFromDb);
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

        public IEnumerable<Request> GetAllRequests()
        {
            return _unitOfWork.Request.GetAll(includeProperties: "Item, Item.Seller, Buyer");
        }

        public IEnumerable<Request> GetAllRequestsByBuyerId(string buyerId)
        {
            return _unitOfWork.Request.GetAll(u => u.BuyerId == buyerId, includeProperties: "Item, Item.Seller, Buyer");
        }

        public IEnumerable<Request> GetAllRequestsBySellerId(string sellerId)
        {
            return _unitOfWork.Request.GetAll(u => u.Item.SellerId == sellerId,includeProperties: "Item, Item.Seller, Buyer");
        }

        public Request GetItemById(int id)
        {
            return _unitOfWork.Request.Get(u => u.Id == id, includeProperties: "Item, Item.Seller, Buyer");
        }

        public Request GetSingleItemById(int id)
        {
            return _unitOfWork.Request.Get(u => u.Id == id);
        }

        public void UpdateRequest(Request Request)
        {
            _unitOfWork.Request.Update(Request);
            _unitOfWork.Save();
        }
    }
}
