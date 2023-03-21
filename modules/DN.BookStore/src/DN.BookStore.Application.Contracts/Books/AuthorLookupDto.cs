using System;
using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
