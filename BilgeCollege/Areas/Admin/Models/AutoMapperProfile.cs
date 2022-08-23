using AutoMapper;
using BilgeCollege.Areas.Admin.Models.Dtos;
using Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BilgeCollege.Areas.Admin.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ogrenci, OgrenciDto>();
            CreateMap<OgrenciDto, Ogrenci>();
            CreateMap<Siniflar, SinifModel>();
            CreateMap<SinifModel, Siniflar>();
            CreateMap<Kullanici, LoginCreateDto>();
            CreateMap<LoginCreateDto, Kullanici>();
            CreateMap<Ders, DersDto>();
            CreateMap<DersDto,Ders>();
            CreateMap<Ogretmen, OgretmenDto>();
            CreateMap<OgretmenDto, Ogretmen>();            // CreateMap<List<Sinif>, List<SinifModel>>();

        }
    }
}
