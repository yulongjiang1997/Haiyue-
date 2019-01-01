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
using Haiyue.Model.Dto.TaskLists;
using Haiyue.Model.Dto.Expenditures;
using Haiyue.Model.Dto.Expenditures.ExpenditureTypes;
using Haiyue.Model.Dto.LeaveAMessages;
using Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys;

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
            CreateMap<ReturnPuurchaseDto, Purchase>().ReverseMap().ForMember(o=>o.Handler,op=>op.MapFrom(a=>a.Handler.Name));
               // .ForMember(o => o.GameName, op => op.MapFrom(a => a.Game.Name));

            CreateMap<ReturnPositionDto, Position>().ReverseMap();
            CreateMap<PositionAddOrEditDto, Position>().ReverseMap();

            CreateMap<CurrencyAddOrEditDto, Currency>().ReverseMap();
            CreateMap<ReturnCurrencyDto, Currency>().ReverseMap();

            CreateMap<NoteBookAddOrEditDto, NoteBook>().ReverseMap();
            CreateMap<ReturnNoteBookDto, NoteBook>().ReverseMap();

            CreateMap<DepartmentAddOrEditDto, Department>().ReverseMap();
            CreateMap<ReturnDepartmentDto, Department>().ReverseMap();

            CreateMap<AddOrEditTaskListDto, TaskList>().ReverseMap();
            CreateMap<AddOrEditTaskListDto, TaskChangeLog>().ReverseMap();
            CreateMap<ReturnTaskChangeLogDto, TaskChangeLog>().ReverseMap().ForMember(o => o.EditTime, op => op.MapFrom(a => a.CreateTime));
            CreateMap<ReturnTaskListDto, TaskList>().ReverseMap();
            CreateMap<ReturnTaskStatueLogDto, TaskStatusLog>().ReverseMap().ForMember(o => o.EditTime, op => op.MapFrom(a => a.CreateTime));
            CreateMap<AddTaskStatusLogDto, TaskStatusLog>().ReverseMap();
            
            CreateMap<AddOrEditExpenditureDto, Expenditure > ().ReverseMap();
            CreateMap<ReturnExpenditureDto, Expenditure > ().ReverseMap().ForMember(o => o.ExpenditureType, op => op.MapFrom(a => a.ExpenditureType.Name))
                                                                         .ForMember(o => o.HandlerName, op => op.MapFrom(a => a.User.Name));

            CreateMap<AddOrEditExpeditureTypeDto, ExpenditureType>().ReverseMap();
            CreateMap<ReturnJurisdictionTypeDto, ExpenditureType>().ReverseMap();

            CreateMap<Model.Dto.LeaveAMessages.AddOrEditLeaveAMessageReplyDto, LeaveAMessage>().ReverseMap();
            CreateMap<ReturnLeaveAMessageDto, LeaveAMessage>().ReverseMap();
            CreateMap<Model.Dto.LeaveAMessages.LeaveAMessageReplys.AddOrEditLeaveAMessageReplyDto, LeaveAMessageReply>().ReverseMap();
            CreateMap<ReturnLeaveAMessageReplyDto, LeaveAMessageReply>().ReverseMap();
        }
    }
}
