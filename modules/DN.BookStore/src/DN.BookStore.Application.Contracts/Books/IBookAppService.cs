using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DN.BookStore.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<BookDto> GetAsync(Guid id);
        Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);
        Task<BookDto> CreateAsync(CreateUpdateBookDto input);
        Task UpdateAsync(Guid id, CreateUpdateBookDto input);
        Task DeleteAsync(Guid id);

        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
