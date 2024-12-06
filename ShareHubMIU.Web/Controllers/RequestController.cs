using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Implementations;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Web.ViewModel;
using System.Security.Claims;

namespace ShareHubMIU.Web.Controllers
{
    [Authorize(Roles = SD.Role_Customer)]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        private readonly IItemService _itemService;

        private readonly UserManager<ApplicationUser> _userManager;

        public RequestController(IRequestService requestService,
                                IItemService itemService,
                                UserManager<ApplicationUser> userManager)
        {
            _requestService =requestService;
            _itemService = itemService;
            _userManager = userManager;
        }

        public IActionResult BuyerIndex()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = _requestService.GetAllRequestsByBuyerId(userId);

            return View(items);
        }

        public IActionResult SellerIndex()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = _requestService.GetAllRequestsBySellerId(userId);

            return View(items);
        }

        public IActionResult RequestItem(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var item = _itemService.GetItemById(itemId);
            ApplicationUser user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            Request request = new Request
            {
                ItemId = item.Id,
                BuyerId = userId,
                Buyer = user,
                Item = item
            };
            return View(request);
        }

        public IActionResult FinalizeRequestItem(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            Request request = new Request
            {
                ItemId = itemId,
                BuyerId = userId
            };

            _requestService.CreateRequest(request);
            TempData["success"] = "The Request has been created successfully.";
            return RedirectToAction(nameof(BuyerIndex));
        }

        public IActionResult Approve(int itemId)
        {
            var request = _requestService.GetSingleItemById(itemId);
            request.Status = SD.RequestStatusApproved;

            _requestService.UpdateRequest(request);
            TempData["success"] = "The Request has been approved successfully.";
            return RedirectToAction(nameof(BuyerIndex));
        }

        public IActionResult Reject(int itemId)
        {
            var request = _requestService.GetSingleItemById(itemId);
            request.Status = SD.RequestStatusRejected;

            _requestService.UpdateRequest(request);
            TempData["success"] = "The Request has been reject successfully.";
            return RedirectToAction(nameof(BuyerIndex));
        }

        public IActionResult ViewDetail(int itemId)
        {
            var request = _requestService.GetItemById(itemId);
            return View(request);
        }
    }
}
