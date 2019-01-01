using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Service.Services.GameServices;
using Haiyue.Service.Services.PurchaseServices;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Models.Dto;

namespace Test.Controllers
{
    public class IndexController : Controller
    {
        private readonly IPurchaseService _service;
        private readonly IGameService _gameService;

        public IndexController(IPurchaseService service, IGameService gameService)
        {
            _service = service;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var indexMdeols = new IndexModel(_service, _gameService);
            var models = await indexMdeols.getModel();
            return View(models);
        }
    }
}