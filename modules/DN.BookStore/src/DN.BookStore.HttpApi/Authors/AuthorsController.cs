using DN.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.GlobalFeatures;

namespace DN.BookStore.Authors
{
    [Authorize(BookStorePermissions.Authors.Default)]
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

        [Authorize(BookStorePermissions.Authors.Create)]
        [HttpPost]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            return await _authorAppService.CreateAsync(input);
        }

        [Authorize(BookStorePermissions.Authors.Delete)]
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

        [Authorize(BookStorePermissions.Authors.Edit)]
        [HttpPut]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            await _authorAppService.UpdateAsync(id, input);
        }
    }
}
