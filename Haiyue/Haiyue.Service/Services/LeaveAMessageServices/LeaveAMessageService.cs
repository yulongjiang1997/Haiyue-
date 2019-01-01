using AutoMapper;
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
    public class LeaveAMessageServiceL:ILeaveAMessageService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public LeaveAMessageServiceL(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(Model.Dto.LeaveAMessages.AddOrEditLeaveAMessageReplyDto model)
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

        public async Task<bool> CreateReplyAsync(Model.Dto.LeaveAMessages.LeaveAMessageReplys.AddOrEditLeaveAMessageReplyDto model)
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

        public async Task<bool> EditAsync(int id, Model.Dto.LeaveAMessages.AddOrEditLeaveAMessageReplyDto model)
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
            var leaveAMessage = _context.LeaveAMessages.AsNoTracking();
            result.Amount = model.Amount;
            result.Total = await leaveAMessage.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnLeaveAMessageDto>>(await leaveAMessage.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
