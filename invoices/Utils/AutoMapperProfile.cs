using AutoMapper;
using invoices.DTOs;
using invoices.Models;

namespace invoices.Utils
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressCreateDto>();
            CreateMap<Sku, SkuCreateDto>();
            CreateMap<SkuDto, Sku>();
        }
    }
}