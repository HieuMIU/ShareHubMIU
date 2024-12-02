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
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateItem(Item Item)
        {
            _unitOfWork.Item.Add(Item);
            _unitOfWork.Save();
        }

        public bool DeleteItem(int id)
        {
            try
            {
                Item? objFromDb = _unitOfWork.Item.Get(u => u.Id == id);
                if (objFromDb is not null)
                {
                    _unitOfWork.Item.Delete(objFromDb);
                    _unitOfWork.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _unitOfWork.Item.GetAll(includeProperties: "Villa");
        }

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(int id)
        {
            return _unitOfWork.Item.Get(u => u.Id == id);
        }

        public bool IsNameExists(int villaId, string name)
        {
            return _unitOfWork.Item.Any(u => u.VillaId == villaId && name.Equals(u.Name));
        }

        public void UpdateItem(Item Item)
        {
            _unitOfWork.Item.Update(Item);
            _unitOfWork.Save();
        }
    }
}
