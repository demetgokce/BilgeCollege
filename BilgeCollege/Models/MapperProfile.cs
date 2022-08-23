using AutoMapper;
using BilgeCollege.Models.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeCollege.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginDto, Kullanici>();
            CreateMap<Kullanici, LoginDto>();
            CreateMap<RegisterDto, Kullanici>();
            CreateMap<Kullanici, RegisterDto>();
        }
    }
}
