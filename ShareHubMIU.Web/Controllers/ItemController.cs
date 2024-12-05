using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using System.Security.Claims;

namespace ShareHubMIU.Web.Controllers
{
    [Authorize(Roles = SD.Role_Customer)]
    public class ItemController : Controller
    {
        private readonly ICarSharingService _carSharingService;

        private readonly IRoomSharingService _roomSharingService;

        private readonly ICommonItemService _commonItemService;

        private readonly IItemService _itemService;

        private readonly UserManager<ApplicationUser> _userManager;

        public ItemController(ICarSharingService carSharingService, 
                                IRoomSharingService roomSharingService, 
                                ICommonItemService commonItemService, 
                                IItemService itemService,
                                UserManager<ApplicationUser> userManager)
        {
            _carSharingService = carSharingService;
            _roomSharingService = roomSharingService;
            _commonItemService = commonItemService;
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAllItems();
            return View(items);
        }

        public IActionResult CustomerIndex()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = _itemService.GetAllItems(userId);

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateCarSharing()
        {
            return View();
        }

        public IActionResult CreateRoomSharing()
        {
            return View();
        }

        public IActionResult CreateCommonItem()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            CommonItem commonItem = new CommonItem()
            {
                SellerId = userId,
                Type = "CommonItem"
            };
            return View(commonItem);
        }

        [HttpPost]
        public IActionResult CreateCarSharing(CarSharing carSharing)
        {
            if (ModelState.IsValid)
            {
                _carSharingService.CreateCarSharing(carSharing);
                TempData["success"] = "The Item has been created successfully.";
                return RedirectToAction(nameof(CustomerIndex));
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateRoomSharing(RoomSharing roomSharing)
        {
            if (ModelState.IsValid)
            {
                _roomSharingService.CreateRoomSharing(roomSharing);
                TempData["success"] = "The Item has been created successfully.";
                return RedirectToAction(nameof(CustomerIndex));
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateCommonItem(CommonItem commonItem)
        {
            if (ModelState.IsValid)
            {
                _commonItemService.CreateCommonItem(commonItem);
                TempData["success"] = "The Item has been created successfully.";
                return RedirectToAction(nameof(CustomerIndex));
            }
            return View();
        }
        //public IActionResult Update(int ItemId)
        //{
        //    ItemVM ItemVM = new ItemVM()
        //    {
        //        Item = _ItemService.GetItemById(ItemId)
        //    };

        //    if (ItemVM.Item == null)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }

        //    return View(ItemVM);
        //}

        //[HttpPost]
        //public IActionResult Update(ItemVM ItemVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _ItemService.UpdateItem(ItemVM.Item);
        //        TempData["success"] = "The Item has been updated successfully.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    TempData["error"] = "The Item could not be updated.";

        //    return View(ItemVM);
        //}

        //public IActionResult Delete(int ItemId)
        //{
        //    ItemVM ItemVM = new ItemVM()
        //    {          
        //        Item = _ItemService.GetItemById(ItemId)
        //    };

        //    if (ItemVM.Item == null)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }

        //    return View(ItemVM);
        //}

        //[HttpPost]
        //public IActionResult Delete(ItemVM ItemVM)
        //{
        //    if(_ItemService.DeleteItem(ItemVM.Item.Id))
        //    {
        //        TempData["success"] = "The Item has been deleted successfully.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    TempData["error"] = "The Item could not be deleted.";
        //    return View();
        //}
    }
}
