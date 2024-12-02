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
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        bool DeleteItem(int id);
    }
}
