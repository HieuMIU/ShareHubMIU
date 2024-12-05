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
    public class CommonItemService : ICommonItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommonItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCommonItem(CommonItem commonItem)
        {
            ArgumentNullException.ThrowIfNull(commonItem);

            _unitOfWork.CommonItem.Add(commonItem);
            _unitOfWork.Save();
        }

        public bool DeleteCommonItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommonItem> GetAllCommonItems()
        {
            throw new NotImplementedException();
        }

        public CommonItem GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommonItem(CommonItem CommonItem)
        {
            throw new NotImplementedException();
        }
    }
}
