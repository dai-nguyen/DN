using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Books
{
    [Area(BookStoreRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
    [Route("api/BookStore/Books")]
    public class BooksController : BookStoreController, IBookAppService
    {
        readonly IBookAppService _bookAppService;

        public BooksController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpPost]
        public async Task<BookDto> CreateAsync([FromBody] CreateUpdateBookDto input)
        {
            return await _bookAppService.CreateAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<BookDto> GetAsync(Guid id)
        {
            return await _bookAppService.GetAsync(id);
        }

        [HttpPost]
        [Route("GetList")]
        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {
            return await _bookAppService.GetListAsync(input);
        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, [FromBody] CreateUpdateBookDto input)
        {
            await _bookAppService.UpdateAsync(id, input);
        }
    }
}
