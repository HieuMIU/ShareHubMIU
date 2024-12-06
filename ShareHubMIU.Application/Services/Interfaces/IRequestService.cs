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
    public interface IRequestService
    {
        IEnumerable<Request> GetAllRequests();
        Request GetItemById(int id);

        Request GetSingleItemById(int id);
        void CreateRequest(Request request);
        void UpdateRequest(Request request);
        bool DeleteRequest(int id);

        IEnumerable<Request> GetAllRequestsBySellerId(string sellerId);

        IEnumerable<Request> GetAllRequestsByBuyerId(string buyerId);
    }
}
