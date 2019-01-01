using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Game;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Service.Services.GameServices;
using Haiyue.Service.Services.PurchaseServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.Dto;

namespace Test.Models
{
    public class IndexModel : PageModel
    {
        private readonly IPurchaseService _service;
        private readonly IGameService _gameService;

        public ReturnPaginSelectDto<ReturnPuurchaseDto> ReturnPuurchase { get; set; }
        public ReturnPaginSelectDto<ReturnGameDto> ReturnGame { get; set; }

        public IndexModel(IPurchaseService service, IGameService gameService)
        {
            _service = service;
            _gameService = gameService;
        }

        public async Task<IndexDateModel> getModel()
        {
            var pm = await _service.QueryPaginAsync(new SelectPurchaseDto() { PageNumber = 1, Amount = 10 });
            var gm = await _gameService.QueryPaginAsync(new SelectGameDto() { PageNumber = 1, Amount = 10 });
            var datemodel = new IndexDateModel();
            datemodel.ReturnGame=gm;
            datemodel.ReturnPuurchase = pm;
            return datemodel;
        }
    }
    public class IndexDateModel : PageModel
    {
        public ReturnPaginSelectDto<ReturnPuurchaseDto> ReturnPuurchase { get; set; }
        public ReturnPaginSelectDto<ReturnGameDto> ReturnGame { get; set; }
    }
}
