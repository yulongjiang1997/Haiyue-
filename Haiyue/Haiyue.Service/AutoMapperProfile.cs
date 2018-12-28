using AutoMapper;
using Haiyue.Model.Dto.Purchase;
using Haiyue.Model.Dto.Game;
using Haiyue.Model.Dto.Positions;
using Haiyue.Model.Dto.Users;
using Haiyue.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Haiyue.Model.Dto.Currencys;
using Haiyue.Model.Dto.NoteBooks;
using Haiyue.Model.Dto.Departments;

namespace Haiyue.Service
{
    public  class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserAddOrEditDto, User>().ReverseMap();
            CreateMap<ReturnUserDto, User>().ReverseMap();

            CreateMap<ReturnGameDto, Game>().ReverseMap();
            CreateMap<GameAddOrEditDto, Game>().ReverseMap();

            CreateMap<PurchaseAddOrEditDto, Purchase>().ReverseMap();
            CreateMap<ReturnPuurchaseDto, Purchase>().ReverseMap();
               // .ForMember(o => o.GameName, op => op.MapFrom(a => a.Game.Name));

            CreateMap<ReturnPositionDto, Position>().ReverseMap();
            CreateMap<PositionAddOrEditDto, Position>().ReverseMap();

            CreateMap<CurrencyAddOrEditDto, Currency>().ReverseMap();
            CreateMap<ReturnCurrencyDto, Currency>().ReverseMap();

            CreateMap<NoteBookAddOrEditDto, NoteBook>().ReverseMap();
            CreateMap<ReturnNoteBookDto, NoteBook>().ReverseMap();

            CreateMap<DepartmentAddOrEditDto, Department>().ReverseMap();
            CreateMap<ReturnDepartmentDto, Department>().ReverseMap();

        }
    }
}
