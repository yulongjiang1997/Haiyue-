﻿using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.LeaveAMessages;
using Haiyue.Model.Dto.LeaveAMessages.LeaveAMessageReplys;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.LeaveAMessageServices
{
    public class LeaveAMessageService : ILeaveAMessageService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public LeaveAMessageService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AddOrEditLeaveAMessageDto model)
        {
            var leaveAMessage = _mapper.Map<LeaveAMessage>(model);
            _context.LeaveAMessages.Add(leaveAMessage);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leaveAMessage = await _context.LeaveAMessages.FirstOrDefaultAsync(i => i.Id == id);
            _context.LeaveAMessages.Remove(leaveAMessage);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateReplyAsync(AddOrEditLeaveAMessageReplyDto model)
        {
            var leaveAMessage = _mapper.Map<LeaveAMessageReply>(model);
            _context.LeaveAMessageReplys.Add(leaveAMessage);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReplyAsync(int id)
        {
            var leaveAMessage = await _context.LeaveAMessageReplys.FirstOrDefaultAsync(i => i.Id == id);
            _context.LeaveAMessageReplys.Remove(leaveAMessage);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, AddOrEditLeaveAMessageDto model)
        {
            var leaveAMessage = await _context.LeaveAMessages.FirstOrDefaultAsync(i => i.Id == id);
            if (leaveAMessage != null)
            {
                _mapper.Map(model, leaveAMessage);
                leaveAMessage.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnLeaveAMessageDto>> QueryPaginAsync(SelectLeaveAMessageDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnLeaveAMessageDto>();
            var leaveAMessage = from lam in _context.LeaveAMessages
                                join lamu in _context.Users on lam.UserId equals lamu.Id
                                select new ReturnLeaveAMessageDto()
                                {
                                    Content = lam.Content,
                                    Id = lam.Id,
                                    CreateTime = lam.CreateTime,
                                    LeaveAMessageReply = null,
                                    Title = lam.Title,
                                    UserName = lamu.Name
                                };
            var resultPagin = await leaveAMessage.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync();
            foreach (var item in resultPagin)
            {
                //循环获得当前留言ID 并通过留言ID获得对应的回复
                item.LeaveAMessageReply = _mapper.Map<List<ReturnLeaveAMessageReplyDto>>( await _context.LeaveAMessageReplys.Include(i => i.ReplyUser).Where(i => i.LeaveAMessageId == item.Id).ToListAsync());
            }
            result.Amount = model.Amount;
            result.Total = await leaveAMessage.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = resultPagin;
            return result;
        }
    }
}
