using DN.BookStore.Samples;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Books
{
    public class BooksController : BookStoreController, IBookAppService
    {
        readonly IBookAppService _bookAppService;

        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpPost]
        public async Task<BookDto> CreateAsync(CreateUpdateBookDto dto)
        {
            return await _bookAppService.CreateAsync(dto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            return await _bookAppService.GetAsync(id);
        }

        public async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await _bookAppService.GetListAsync(input);
        }

        public async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            return await _bookAppService.UpdateAsync(id, input);
        }
    }
}
