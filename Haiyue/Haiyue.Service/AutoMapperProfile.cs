using AutoMapper;
using EPMS.Model.Dto.Purchase;
using Haiyue.Model.Dto.Game;
using Haiyue.Model.Dto.Positions;
using Haiyue.Model.Dto.Users;
using Haiyue.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Service
{
    public  class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAddOrEditDto, User>().ReverseMap();
            CreateMap<ReturnGameDto, Game>().ReverseMap();
            CreateMap<GameAddOrEditDto, Game>().ReverseMap();
            CreateMap<PurchaseAddOrEditDto, Purchase>().ReverseMap();
            CreateMap<ReturnPositionDto, Position>().ReverseMap();

        }
    }
}
