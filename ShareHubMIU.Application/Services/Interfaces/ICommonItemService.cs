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
    public interface ICommonItemService
    {
        IEnumerable<CommonItem> GetAllCommonItems();
        CommonItem GetItemById(int id);
        void CreateCommonItem(CommonItem commonItem);
        void UpdateCommonItem(CommonItem commonItem);
        bool DeleteCommonItem(int id);
    }
}
