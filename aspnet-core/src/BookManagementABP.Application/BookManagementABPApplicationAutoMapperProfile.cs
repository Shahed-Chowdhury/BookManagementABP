using AutoMapper;
using BookManagementABP.Authors;
using BookManagementABP.Book_Authors;
using BookManagementABP.Books;
using BookManagementABP.Invited_Users;
using BookManagementABP.Publishers;

namespace BookManagementABP;

public class BookManagementABPApplicationAutoMapperProfile : Profile
{
    public BookManagementABPApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDTO>();
        CreateMap<CreateUpdateAuthorDTO, Author>();
        CreateMap<Publisher, PublisherDTO>();
        CreateMap<CreateUpdatePublisherDTO, Publisher>();
        CreateMap<Book_Author, BookAuthorDTO>();
        CreateMap<CreateUpdateBookAuthorDTO, Book_Author>();
        CreateMap<Invited_User, InvitedUserDTO>();
        CreateMap<CreateUpdateInvitedUserDTO, Invited_User>();
    }
}
