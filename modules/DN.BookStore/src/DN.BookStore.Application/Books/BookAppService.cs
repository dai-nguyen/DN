using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace DN.BookStore.Books
{
    public class BookAppService : BookStoreAppService, IBookAppService
    {
        readonly IBookRepository _repository;

        public BookAppService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
        {
            var book = ObjectMapper.Map<CreateUpdateBookDto, Book>(input);
            await _repository.InsertAsync(book);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Book.Name);
            }

            var books = await _repository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<BookDto>(
                totalCount,
                ObjectMapper.Map<List<Book>, List<BookDto>>(books)
            );
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _repository.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            var book = await _repository.GetAsync(id);
            
            ObjectMapper.Map(input, book);

            await _repository.UpdateAsync(book);

        }
    }
}
