using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Client, ClientDto>()
            .ReverseMap();
        CreateMap<Request, RequestDto>()
            .ReverseMap();    
        CreateMap<Employee, EmployeeDto>()
            .ReverseMap();               
        CreateMap<Office, OfficeDto>()
            .ReverseMap();       
        CreateMap<Requestdetail, Requestdetail>()
            .ReverseMap();   
        CreateMap<Product, ProductDto>()
            .ReverseMap();   
        CreateMap<Producttype, ProducttypeDto>()
            .ReverseMap();   
        CreateMap<Payment, PaymentDto>()
            .ReverseMap();                              
    }
        
}