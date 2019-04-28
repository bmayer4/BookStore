using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StoreApp.API.Dtos;
using StoreApp.API.Models;

namespace StoreApp.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // source to dest
            CreateMap<UserForRegisterDto, User>();

            CreateMap<User, UserToReturnDto>();

            CreateMap<OrderForCreationDto, Order>();

            CreateMap<Order, OrderForUserToReturnDto>()
                .ForMember(dest => dest.TotalOrderPrice, opt => {
                    opt.MapFrom(src => src.OrderItems.Sum(o => o.Quantity * o.Book.Price));
                });

            CreateMap<Order, OrderForGuestToReturnDto>()
            .ForMember(dest => dest.TotalOrderPrice, opt => {
                    opt.MapFrom(src => src.OrderItems.Sum(o => o.Quantity * o.Book.Price));
                });

            CreateMap<OrderItemForCreationDto, OrderItem>();
            
            CreateMap<BookForCreationDto, Book>();

            CreateMap<AuthorForCreationDto, Author>();

            CreateMap<Book, BookForDetailDto>();
            
            CreateMap<Book, BookForListDto>();

            CreateMap<OrderItemToReturnDto, OrderItem>();
        }    
    }
}