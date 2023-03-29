using Blazorise;
using Blazorise.DataGrid;
using DN.BookStore.Books;
using DN.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Blazor.Pages.BookStore
{
    public partial class Books
    {
        [Inject] protected IBookAppService AppService { get; set; }        
        
        private IReadOnlyList<BookDto> BookList { get; set; }
        IReadOnlyList<AuthorLookupDto> AuthorList = Array.Empty<AuthorLookupDto>();

        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        
        private bool CanCreateBook { get; set; }
        private bool CanEditBook { get; set; }
        private bool CanDeleteBook { get; set; }

        private CreateUpdateBookDto NewBook { get; set; }

        private Guid EditingBookId { get; set; }
        private CreateUpdateBookDto EditingBook { get; set; }

        private Modal CreateBookModal { get; set; }
        private Modal EditBookModal { get; set; }

        private Validations CreateValidationsRef;
        private Validations EditValidationsRef;

        public Books()
        {
            NewBook = new CreateUpdateBookDto();
            EditingBook = new CreateUpdateBookDto();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await GetBooksAsync();
            var res = await AppService.GetAuthorLookupAsync();

            if (res != null)
                AuthorList = res.Items;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateBook = await AuthorizationService
                .IsGrantedAsync(BookStorePermissions.Books.Create);
            CanEditBook = await AuthorizationService
                .IsGrantedAsync(BookStorePermissions.Books.Edit);
            CanDeleteBook = await AuthorizationService
                .IsGrantedAsync(BookStorePermissions.Books.Delete);
        }

        private async Task GetBooksAsync()
        {
            var result = await BookAppService.GetListAsync(new GetBookListDto()
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            });

            BookList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<BookDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page - 1;

            await GetBooksAsync();

            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateBookModalAsync()
        {
            if (!AuthorList.Any())
            {
                throw new UserFriendlyException(message: L["AnAuthorIsRequiredForCreatingBook"]);
            }

            await CreateValidationsRef.ClearAll();

            NewBook = new CreateUpdateBookDto();
            NewBook.AuthorId = AuthorList.First().Id;

            await CreateBookModal.Show();
        }

        private async Task CloseCreateBookModalAsync()
        {
            await CreateBookModal.Hide();
        }

        private async Task OpenEditBookModalAsync(BookDto book)
        {
            await EditValidationsRef.ClearAll();

            EditingBookId = book.Id;
            EditingBook = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(book);
            await EditBookModal.Show();
        }

        private async Task DeleteBookAsync(BookDto book)
        {
            var confirmMessage = L["BookDeletionConfirmationMessage", book.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await BookAppService.DeleteAsync(book.Id);
            await GetBooksAsync();
        }

        private async Task CloseEditBookModalAsync()
        {
            await EditBookModal.Hide();
        }

        private async Task CreateBookAsync()
        {
            if (await CreateValidationsRef.ValidateAll())
            {
                await BookAppService.CreateAsync(NewBook);
                await GetBooksAsync();
                await CreateBookModal.Hide();
            }
        }

        private async Task UpdateBookAsync()
        {
            if (await EditValidationsRef.ValidateAll())
            {
                await BookAppService.UpdateAsync(EditingBookId, EditingBook);
                await GetBooksAsync();
                await EditBookModal.Hide();
            }
        }
    }
}
