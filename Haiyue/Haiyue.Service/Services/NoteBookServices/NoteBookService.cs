using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Haiyue.HYEF;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.NoteBooks;
using Haiyue.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace Haiyue.Service.Services.NoteBookServices
{
    public class NoteBookService : INoteBookService
    {
        private readonly HYContext _context;
        private readonly IMapper _mapper;

        public NoteBookService(HYContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(NoteBookAddOrEditDto model)
        {
            var noteBook = _mapper.Map<NoteBook>(model);
            _context.NoteBooks.Add(noteBook);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var noteBook= await _context.NoteBooks.FirstOrDefaultAsync(i=>i.Id==id);
            _context.NoteBooks.Remove(noteBook);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(int id, NoteBookAddOrEditDto model)
        {
            var noteBook = await _context.NoteBooks.FirstOrDefaultAsync(i => i.Id == id);
            if(noteBook!=null)
            {
                _mapper.Map(model, noteBook);
                noteBook.LastUpTime = DateTime.Now;
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnPaginSelectDto<ReturnNoteBookDto>> QueryPaginAsync(SelectNoteBoolDto model)
        {
            var result = new ReturnPaginSelectDto<ReturnNoteBookDto>();
            var noteBooks = _context.NoteBooks.AsNoTracking();
            result.Amount = model.Amount;
            result.Total = await noteBooks.CountAsync();
            result.PageNumber = model.PageNumber;
            result.Items = _mapper.Map<List<ReturnNoteBookDto>>(await noteBooks.Pagin(model).OrderBy(i => i.CreateTime).ToListAsync());
            return result;
        }
    }
}
