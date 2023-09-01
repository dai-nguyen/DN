using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DN.CRM.Contacts
{
    public class GetContactListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
