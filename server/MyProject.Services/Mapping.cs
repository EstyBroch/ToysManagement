using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Repositories.LocalEntities;
using MyProject.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyProject.Services
{
    public class Mapping:Profile
    {
        public Mapping()
        {            
          
            CreateMap<User,UserDTO>().ReverseMap();

            CreateMap<Order,OrderDTO>().ReverseMap();

            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<ProductOrdersCount, ProductOrdersCountDTO>().ReverseMap();



        }
    }
}
