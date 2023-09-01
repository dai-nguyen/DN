using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DN.CRM.Contacts
{
    public interface IContactAppService : IApplicationService
    {
        Task<ContactDto> GetAsync(Guid id);
        Task<PagedResultDto<ContactDto>> GetListAsync(GetContactListDto input);
        Task<ContactDto> CreateAsync(CreateContactDto input);
        Task UpdateAsync(Guid id, UpdateContactDto input);
        Task DeleteAsync(Guid id);
    }
}
