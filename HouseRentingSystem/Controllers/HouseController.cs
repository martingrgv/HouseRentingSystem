using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Contracts.Agent;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using Microsoft.AspNetCore.Identity;
using HouseRentingSystem.Core;
using HouseRentingSystem.Infrastructure.Extensions;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(
            IHouseService _houseService,
            IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel query)
        {
            var model = await houseService.AllAsync(
                query.Category,
                query.SearchItem,
                query.HouseSorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage
            );

            query.TotalHousesCount = model.TotalHousesCount;
            query.Houses = model.Houses;

            var categories = await houseService.AllCategoriesNamesAsync();
            query.Categories = categories;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<HouseServiceModel> myHouses = null!;

            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                var currentAgentId = await agentService.GetAgentByIdAsync(User.Id());
                myHouses = await houseService.AllHousesByAgentId(currentAgentId);
            }
            else
            {
                myHouses = await houseService.AllHousesByUserId(User.Id());
            }

            return View(myHouses);
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await houseService.HouseDetailsByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            if (!await agentService.ExistsByIdAsync(User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new HouseFormModel()
            {
                Categories = await houseService.AllHouseCategoriesAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (!await agentService.ExistsByIdAsync(User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if (!await houseService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryNotExistingMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllHouseCategoriesAsync();
                return View(model);
            }

            int agentId = (int) await agentService.GetAgentByIdAsync(User.Id());
            int houseId = await houseService.CreateAsync(model, agentId);

            return RedirectToAction(nameof(Details), new { id = houseId, information = model.GetInformation() });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithId(id, User.Id()))
            {
                return Unauthorized();
            }

            var house = await houseService.HouseDetailsByIdAsync(id);
            var houseCategoryId = await houseService.GetHouseCategoryId(id);

            var categories = await houseService.AllCategoriesAsync();

            var model = new HouseFormModel
            {
                Title = house.Title,
                Address = house.Title,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                CategoryId = houseCategoryId,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel house)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithId(id, User.Id()))
            {
                return Unauthorized();
            }

            if (!await houseService.CategoryExistsAsync(house.CategoryId))
            {
                ModelState.AddModelError(nameof(house.CategoryId), 
                    "Category doesn't exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(house);
            }

            await houseService.Edit(id, house.Title, house.Address, house.Description, house.ImageUrl, house.PricePerMonth, house.CategoryId);

            return RedirectToAction(nameof(Details), new { id = id, information = house.GetInformation()});
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithId(id, User.Id()))
            {
                return Unauthorized();
            }

            var model = await houseService.HouseDetailsByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel house)
        {
            if (!await houseService.ExistsAsync(house.Id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithId(house.Id, User.Id()))
            {
                return Unauthorized();
            }

            await houseService.DeleteAsync(house.Id);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (await houseService.IsRented(id))
            {
                return BadRequest();
            }

            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            await houseService.Rent(id, User.Id());
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await houseService.IsRentedWithUserWithId(id, User.Id()))
            {
                return Unauthorized();
            }

            await houseService.LeaveAsync(id, User.Id());
            return RedirectToAction(nameof(Mine));
        }
    }
}
