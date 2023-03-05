using AutoMapper;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.Categories_Products;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoriesDto, Category>();
            this.CreateMap<ImportCategoriesProductsDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductsDto>().ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
            this.CreateMap<Product, ExportUsersSoldProductDtop>()
                .ForMember(d => d.buyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.buyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            this.CreateMap<User, ExportUsersWithSoldProductDto>()
                .ForMember(d => d.soldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<Product, ExportSoldPRoductShortInfoDto>();
            this.CreateMap<User, ExportSoldProductsFullInfoDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));
            this.CreateMap<User, ExportUsersWithFullProductInfoDto>()
                .ForMember(d => d.SoldProductsInfo, mo => mo.MapFrom(s => s));
        }
    }
}
