﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.GlobalFeatures;

namespace DN.BookStore.Authors
{
    [GlobalFeatureName("BookStore.Author")]
    public class AuthorAppService : BookStoreAppService, IAuthorAppService
    {
        readonly IAuthorRepository _authorRepository;
        readonly AuthorManager _authorManager;

        public AuthorAppService(
            IAuthorRepository authorRepository, 
            AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio);

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            var totalCount = input.Filter == null 
                ? await _authorRepository.CountAsync() 
                : await _authorRepository.CountAsync(_ => _.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(totalCount, 
                ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
        }

        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }
    }
}
