using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace DN.BookStore.Books
{
    public class BookAppService_Tests : BookStoreApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await _bookAppService.GetListAsync(
                new GetBookListDto());

            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(_ => _.Name == "1984");
        }
    }
}
