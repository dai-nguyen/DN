﻿using AutoMapper;
using DN.BookStore.Authors;
using DN.BookStore.Books;
using Volo.Abp.AutoMapper;

namespace DN.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        
        CreateMap<Book, BookDto>()
            .ForMember(_ => _.AuthorName, map => map.Ignore());

        CreateMap<CreateUpdateBookDto, Book>()
            .IgnoreAuditedObjectProperties()
            .ForMember(_ => _.ExtraProperties, map => map.Ignore())
            .ForMember(_ => _.Id, map => map.Ignore())
            .ForMember(_ => _.ConcurrencyStamp, map => map.Ignore());

        CreateMap<Author, AuthorDto>();
        CreateMap<CreateAuthorDto, Author>()
            .IgnoreFullAuditedObjectProperties()
            .ForMember(_ => _.ExtraProperties, map => map.Ignore())
            .ForMember(_ => _.Id, map => map.Ignore())
            .ForMember(_ => _.ConcurrencyStamp, map => map.Ignore());

        CreateMap<UpdateAuthorDto, Author>()
            .IgnoreFullAuditedObjectProperties()
            .ForMember(_ => _.ExtraProperties, map => map.Ignore())
            .ForMember(_ => _.Id, map => map.Ignore())
            .ForMember(_ => _.ConcurrencyStamp, map => map.Ignore());

        CreateMap<Author, AuthorLookupDto>();
    }
}
