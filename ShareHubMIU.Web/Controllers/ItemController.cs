using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareHubMIU.Application.Common.Utility;
using ShareHubMIU.Application.Services.Interfaces;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Web.ViewModel;
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
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = _itemService.GetAllItems(userId);

            return View(items);
        }

        public IActionResult CreateCarSharing()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var carSharingVM = new CarSharingVM()
            {
                CarSharing = new CarSharing()
                {
                    SellerId = userId,
                    Type = SD.CategoryTypeCarSharing.ToString()
                },
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(carSharingVM);
        }

        public IActionResult CreateRoomSharing()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var roomSharingVM = new RoomSharingVM()
            {
                RoomSharing = new RoomSharing()
                {
                    SellerId = userId,
                    Type = SD.CategoryTypeRoomSharing.ToString()
                },
                RoomTypes = new List<string>()
                {
                    SD.RoomTypeSingle.ToString(),
                    SD.RoomTypeShared.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(roomSharingVM);
        }

        public IActionResult CreateCommonItem()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var commonItemVM = new CommonItemVM()
            {
                CommonItem = new CommonItem()
                {
                    SellerId = userId
                },
                Categories = new List<string>()
                {
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                }),
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(commonItemVM);
        }

        [HttpPost]
        public IActionResult CreateCarSharing(CarSharing carSharing)
        {
            if (ModelState.IsValid)
            {
                _carSharingService.CreateCarSharing(carSharing);
                TempData["success"] = "The Item has been created successfully.";
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult UpdateCarSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarSharing carSharing = _carSharingService.GetItemById(itemId);
            if (carSharing == null) {
                return RedirectToAction("Error", "Home");
            }

            var carSharingVM = new CarSharingVM()
            {
                CarSharing = carSharing,
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(carSharingVM);
        }
        public IActionResult UpdateRoomSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            RoomSharing roomSharing = _roomSharingService.GetItemById(itemId);
            if (roomSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var roomSharingVM = new RoomSharingVM()
            {
                RoomSharing = roomSharing,
                RoomTypes = new List<string>()
                {
                    SD.RoomTypeSingle.ToString(),
                    SD.RoomTypeShared.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(roomSharingVM);
        }

        public IActionResult UpdateCommonItem(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CommonItem commonItem = _commonItemService.GetItemById(itemId);
            if (commonItem == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var commonItemVM = new CommonItemVM()
            {
                CommonItem = commonItem,
                Categories = new List<string>()
                {
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                }),
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(commonItemVM);
        }

        [HttpPost]
        public IActionResult UpdateCarSharing(CarSharingVM carSharingVM)
        {
            if (ModelState.IsValid)
            {
                _carSharingService.UpdateCarSharing(carSharingVM.CarSharing);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(carSharingVM);
        }

        [HttpPost]
        public IActionResult UpdateRoomSharing(RoomSharingVM roomSharingVM)
        {
            if (ModelState.IsValid)
            {
                _roomSharingService.UpdateRoomSharing(roomSharingVM.RoomSharing);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(roomSharingVM);
        }

        [HttpPost]
        public IActionResult UpdateCommonItem(CommonItemVM commonItemVM)
        {
            if (ModelState.IsValid)
            {
                _commonItemService.UpdateCommonItem(commonItemVM.CommonItem);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(commonItemVM);
        }

        public IActionResult DeleteCarSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarSharing carSharing = _carSharingService.GetItemById(itemId);
            if (carSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var carSharingVM = new CarSharingVM()
            {
                CarSharing = carSharing,
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(carSharingVM);
        }
        public IActionResult DeleteRoomSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            RoomSharing roomSharing = _roomSharingService.GetItemById(itemId);
            if (roomSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var roomSharingVM = new RoomSharingVM()
            {
                RoomSharing = roomSharing,
                RoomTypes = new List<string>()
                {
                    SD.RoomTypeSingle.ToString(),
                    SD.RoomTypeShared.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(roomSharingVM);
        }

        public IActionResult DeleteCommonItem(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CommonItem commonItem = _commonItemService.GetItemById(itemId);
            if (commonItem == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var commonItemVM = new CommonItemVM()
            {
                CommonItem = commonItem,
                Categories = new List<string>()
                {
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                }),
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(commonItemVM);
        }

        [HttpPost]
        public IActionResult DeleteCarSharing(CarSharingVM carSharingVM)
        {
            if (ModelState.IsValid)
            {
                _carSharingService.DeleteCarSharing(carSharingVM.CarSharing.Id);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(carSharingVM);
        }

        [HttpPost]
        public IActionResult DeleteRoomSharing(RoomSharingVM roomSharingVM)
        {
            if (ModelState.IsValid)
            {
                _roomSharingService.DeleteRoomSharing(roomSharingVM.RoomSharing.Id);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(roomSharingVM);
        }

        [HttpPost]
        public IActionResult DeleteCommonItem(CommonItemVM commonItemVM)
        {
            if (ModelState.IsValid)
            {
                _commonItemService.DeleteCommonItem(commonItemVM.CommonItem.Id);
                TempData["success"] = "The Item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Item could not be updated.";

            return View(commonItemVM);
        }

        public IActionResult ViewCarSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CarSharing carSharing = _carSharingService.GetItemById(itemId);
            if (carSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var carSharingVM = new CarSharingVM()
            {
                CarSharing = carSharing,
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(carSharingVM);
        }
        public IActionResult ViewRoomSharing(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            RoomSharing roomSharing = _roomSharingService.GetItemById(itemId);
            if (roomSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var roomSharingVM = new RoomSharingVM()
            {
                RoomSharing = roomSharing,
                RoomTypes = new List<string>()
                {
                    SD.RoomTypeSingle.ToString(),
                    SD.RoomTypeShared.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(roomSharingVM);
        }

        public IActionResult ViewCommonItem(int itemId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CommonItem commonItem = _commonItemService.GetItemById(itemId);
            if (commonItem == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var commonItemVM = new CommonItemVM()
            {
                CommonItem = commonItem,
                Categories = new List<string>()
                {
                    SD.CategoryTypeElectronics.ToString(),
                    SD.CategoryTypeFuniture.ToString(),
                    SD.CategoryTypeMiscellaneous.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                }),
                Conditions = new List<string>()
                {
                    SD.ConditionNew.ToString(),
                    SD.ConditionUsedLikeNew.ToString(),
                    SD.ConditionUsedGood.ToString(),
                    SD.ConditionUsedFair.ToString()
                }.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                })
            };

            return View(commonItemVM);
        }

        public IActionResult UpdateStatusCarSharing(int itemId, string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            CarSharing carSharing = _carSharingService.GetItemById(itemId);
            if (carSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }
            carSharing.Status = status;
            _carSharingService.UpdateCarSharing(carSharing);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateStatusRoomBooking(int itemId, string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            RoomSharing romeSharing = _roomSharingService.GetItemById(itemId);
            if (romeSharing == null)
            {
                return RedirectToAction("Error", "Home");
            }
            romeSharing.Status = status;
            _roomSharingService.UpdateRoomSharing(romeSharing);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateStatusCommonItem(int itemId, string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            CommonItem commonItem = _commonItemService.GetItemById(itemId);
            if (commonItem == null)
            {
                return RedirectToAction("Error", "Home");
            }
            commonItem.Status = status;
            _commonItemService.UpdateCommonItem(commonItem);
            return RedirectToAction(nameof(Index));
        }
    }
}
