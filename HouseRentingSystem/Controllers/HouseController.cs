using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Contracts.Agent;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;

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
        public IActionResult All()
        {
            var model = new AllHousesQueryModel();
            return View(model);
        }

        public IActionResult Mine()
        {
            var model = new AllHousesQueryModel();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = new HouseDetailsViewModel();
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
