using HouseRentingSystem.Core.Contracts.Agent;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        public async Task<IActionResult> Become()
        {
            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            var userId = User.Id();

            if (await agentService.ExistsByIdAsync(userId))
            {
                return BadRequest();
            }
            if (await agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExistsMessage);
            }
            if (await agentService.UserHasRentAsync(userId))
            {
                ModelState.AddModelError("Error", AgentHasRentMessage);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await agentService.CreateAsync(userId, model.PhoneNumber);
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
