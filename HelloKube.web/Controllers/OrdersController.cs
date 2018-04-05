using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HelloKube.Models;

namespace HelloKube.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private core.services.OrderDataService _orderDataService;
        public OrdersController(core.services.OrderDataService ods){
            _orderDataService = ods;
        }
        public IActionResult Index()
        {
            var orders = _orderDataService.GetOrders(100);
            return View(orders);
        }

        public IActionResult Countries()
        {
            var cache = core.services.CacheService.Connection.GetDatabase();

            var countries =Newtonsoft.Json.JsonConvert.DeserializeObject<List<core.dal.Countries>>(cache.StringGet("country-list"));

            return View(countries);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
