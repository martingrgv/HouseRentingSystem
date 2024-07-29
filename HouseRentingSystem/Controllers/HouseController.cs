using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Contracts.Agent;
using HouseRentingSystem.Core.Services.Agent;
using System.Security.Claims;

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
        public IActionResult Add(HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
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
