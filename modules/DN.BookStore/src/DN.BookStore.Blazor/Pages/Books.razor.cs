using Blazorise;
using Blazorise.DataGrid;
using DN.BookStore.Books;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DN.BookStore.Blazor.Pages
{
    public partial class Books
    {
        [Inject] protected IBookAppService AppService { get; set; }        
        
        private IReadOnlyList<BookDto> BookList { get; set; }

        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        
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
            await GetBooksAsync();
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
            await CreateValidationsRef.ClearAll();

            NewBook = new CreateUpdateBookDto();
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
