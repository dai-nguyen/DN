using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Books
{
    public class GetBookListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
