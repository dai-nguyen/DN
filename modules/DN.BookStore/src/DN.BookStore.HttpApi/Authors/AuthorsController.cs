using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.GlobalFeatures;

namespace DN.BookStore.Authors
{
    [RequiresGlobalFeature("BookStore.Author")]
    [Area(BookStoreRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
    [Route("api/BookStore/Authors")]
    public class AuthorsController : BookStoreController, IAuthorAppService
    {
        readonly IAuthorAppService _authorAppService;

        public AuthorsController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [HttpPost]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            return await _authorAppService.CreateAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _authorAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            return await _authorAppService.GetAsync(id);
        }

        [HttpPost]
        [Route("GetList")]
        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            return await _authorAppService.GetListAsync(input);
        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            await _authorAppService.UpdateAsync(id, input);
        }
    }
}
