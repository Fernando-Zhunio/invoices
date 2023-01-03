using AutoMapper;
using invoices.DTOs;
using invoices.Models;

namespace invoices.Utils
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<Address, AddressCreateDto>();
            CreateMap<AddressDto, AddressDto>();
            CreateMap<AddressCreateDto, Address>();

            CreateMap<Brand, BrandDto>();
            CreateMap<Brand, BrandCreateDto>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<BrandDto, Brand>();

            CreateMap<Attachment, AttachmentDto>();
            CreateMap<Attachment, AttachmentCreateDto>();
            CreateMap<AttachmentCreateDto, Attachment>();
            CreateMap<AttachmentDto, Attachment>();

            CreateMap<TypeAttachment, TypeAttachmentDto>();
            CreateMap<TypeAttachment, TypeAttachmentCreateDto>();
            CreateMap<TypeAttachmentDto, TypeAttachment>();
            CreateMap<TypeAttachmentCreateDto, TypeAttachment>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryDto, Category>();

            CreateMap<SkuDto, Sku>();
            CreateMap<Sku, SkuCreateDto>();
        }
    }
}