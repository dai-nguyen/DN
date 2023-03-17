using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace DN.BookStore.Authors
{    
    internal class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(BookStoreErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
        
    }
}