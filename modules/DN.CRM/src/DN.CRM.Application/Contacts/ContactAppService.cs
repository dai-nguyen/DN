using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.GlobalFeatures;

namespace DN.CRM.Contacts
{
    [GlobalFeatureName("CRM.Contact")]
    public class ContactAppService : CRMAppService, IContactAppService
    {
        readonly IContactRepository _contactRepository;

        public ContactAppService(
            IContactRepository contactRepository) 
        { 
            _contactRepository = contactRepository;
        }

        public async Task<ContactDto> CreateAsync(CreateContactDto input)
        {
            var entity = ObjectMapper.Map<CreateContactDto, Contact>(input);
            await _contactRepository.InsertAsync(entity);
            return ObjectMapper.Map<Contact, ContactDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<ContactDto> GetAsync(Guid id)
        {
            var entity = await _contactRepository.GetAsync(id);
            return ObjectMapper.Map<Contact, ContactDto>(entity);
        }

        public async Task<PagedResultDto<ContactDto>> GetListAsync(GetContactListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
                input.Sorting = nameof(Contact.FirstName);

            var entities = await _contactRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            var totalCount = input.Filter == null 
                ? await _contactRepository.CountAsync() 
                : await _contactRepository.CountAsync(_ => _.FirstName.Contains(input.Filter) || _.LastName.Contains(input.Filter));

            return new PagedResultDto<ContactDto>(
                totalCount,
                ObjectMapper.Map<List<Contact>, List<ContactDto>>(entities));
        }

        public async Task UpdateAsync(Guid id, UpdateContactDto input)
        {
            var entity = await _contactRepository.GetAsync(id);

            ObjectMapper.Map(input, entity);

            await _contactRepository.UpdateAsync(entity);
        }
    }
}
