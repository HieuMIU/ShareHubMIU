﻿using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareHubMIU.Application.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Item> GetAllItems(string? userId = null, string? status = null, string? type = null)
        {
            return _unitOfWork.Item.GetAll(u => (userId == null || userId == u.SellerId)
                                                    && (status == null || status == u.Status)
                                                    && (type == null || type == u.Type));
        }

        public Item GetItemById(int id)
        {
            return _unitOfWork.Item.Get(u => u.Id == id, includeProperties: "Seller");
        }
    }
}
