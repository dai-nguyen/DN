//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Volo.Abp;

//namespace DN.BookStore.Samples;

//[Area(BookStoreRemoteServiceConsts.ModuleName)]
//[RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
//[Route("api/BookStore/sample")]
//public class SampleController : BookStoreController, ISampleAppService
//{
//    private readonly ISampleAppService _sampleAppService;

//    public SampleController(ISampleAppService sampleAppService)
//    {
//        _sampleAppService = sampleAppService;
//    }

//    [HttpGet]
//    public async Task<SampleDto> GetAsync()
//    {
//        return await _sampleAppService.GetAsync();
//    }

//    [HttpGet]
//    [Route("authorized")]
//    [Authorize]
//    public async Task<SampleDto> GetAuthorizedAsync()
//    {
//        return await _sampleAppService.GetAsync();
//    }
//}
