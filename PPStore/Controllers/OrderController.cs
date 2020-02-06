using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PPStore.Models;
using PPStore.Models.View;
using PPStore.Services.Interfaces;

namespace PPStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly UserManager<PPUser> _userManager;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService, UserManager<PPUser> userManager)
        {
            _logger = logger;
            _orderService = orderService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrder(NewPizzaOrder newOrder)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _orderService.CreateOrder(newOrder, user);
            return Accepted();
        }
    }
}