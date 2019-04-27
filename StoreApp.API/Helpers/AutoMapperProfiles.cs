using System.Collections.Generic;
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

            CreateMap<Order, OrderForUserToReturnDto>();

            CreateMap<Order, OrderForGuestToReturnDto>();

            CreateMap<OrderItemForCreationDto, OrderItem>();
            
            CreateMap<BookForCreationDto, Book>();

            CreateMap<AuthorForCreationDto, Author>();

            CreateMap<Book, BookForDetailDto>();
            
            CreateMap<Book, BookForListDto>();

            CreateMap<OrderItemToReturnDto, OrderItem>();
        }    
    }
}