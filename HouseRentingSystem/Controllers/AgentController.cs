using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Contracts.Agent;

namespace HouseRentingSystem.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
