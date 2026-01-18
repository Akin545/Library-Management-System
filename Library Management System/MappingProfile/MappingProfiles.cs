using AutoMapper;

using Library.Management.System.Core.Dtos.Book;
using Library.Management.System.Core.Dtos.User;
using Library.Management.System.Core.Models;

using System.Net.Sockets;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library_Management_System.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region User
            CreateMap<UserDto, User>(MemberList.None).ReverseMap();
            CreateMap<CreateUserDto, User>(MemberList.None)
                .ForMember(r => r.PasswordHash, o => o.MapFrom(s => s.Password)).ReverseMap();

            CreateMap<LoginDto, User>(MemberList.None)
                .ForMember(r => r.PasswordHash, o => o.MapFrom(s => s.Password)).ReverseMap();

            #endregion
          

            #region Book
            CreateMap<Book, BookDTO>(MemberList.None).ReverseMap();
            CreateMap<SearchBookDTO, Book>(MemberList.None).ReverseMap();
            CreateMap<CreateBookDTO, Book>(MemberList.None).ReverseMap();
            CreateMap<UpdateBookDTO, BookDTO>(MemberList.None).ReverseMap();

            #endregion
        }
    }
}