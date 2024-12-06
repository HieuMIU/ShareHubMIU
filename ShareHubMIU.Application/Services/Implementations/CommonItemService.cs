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

            //set default value
            commonItem.DateListed = DateTime.Now;

            _unitOfWork.CommonItem.Add(commonItem);
            _unitOfWork.Save();
        }

        public bool DeleteCommonItem(int id)
        {
            try
            {
                CommonItem? objFromDb = _unitOfWork.CommonItem.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.CommonItem.Remove(objFromDb);
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

        public IEnumerable<CommonItem> GetAllCommonItems()
        {
            return _unitOfWork.CommonItem.GetAll();
        }

        public CommonItem GetItemById(int id)
        {
            return _unitOfWork.CommonItem.Get(u => u.Id == id);
        }

        public void UpdateCommonItem(CommonItem CommonItem)
        {
            _unitOfWork.CommonItem.Update(CommonItem);
            _unitOfWork.Save();
        }
    }
}
