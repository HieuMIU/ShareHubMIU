using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareHubMIU.Application.Common.Interfaces;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Infrastructure.Data;

namespace ShareHubMIU.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ItemController : Controller
    {
        private readonly ICarSharingService _ItemService;

        public ItemController(ICarSharingService ItemService)
        {
            _ItemService = ItemService;
        }

        public IActionResult Index()
        {
            var carSharings = _ItemService.GetAllCarSharings();
            return View(carSharings);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(ItemVM ItemVM)
        //{
        //    _ItemService.CreateItem(ItemVM.Item);
        //    TempData["success"] = "The Item has been created successfully.";
        //    return RedirectToAction(nameof(Index));

        //    if (nameExists)
        //    {
        //        TempData["error"] = "The Item already exists.";
        //    }
        //    return View(ItemVM);
        //}

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
