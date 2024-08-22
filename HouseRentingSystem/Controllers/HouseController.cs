using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Contracts.Agent;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using Microsoft.AspNetCore.Identity;

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

        public async Task<IActionResult> Details(int id)
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

            return RedirectToAction(nameof(Details), new { id = houseId });
        }

        public IActionResult Edit(int id)
        {
            var model = new HouseFormModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel house)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        public IActionResult Delete(int id)
        {
            var model = new HouseFormModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(HouseDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
