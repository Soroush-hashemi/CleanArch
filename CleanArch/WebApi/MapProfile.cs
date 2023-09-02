using Application.Query.Products.DTOs;
using AutoMapper;
using ReadModel.Entities.ProductAgg;
using WebApi.ViewModels.Products;

namespace WebApi
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // اینجا ما مپ میکنیم از رید مدل به ویو مدل 
            CreateMap<ProductDto, ProductViewModel>().ReverseMap(); // اگر برعکس هم مپ بکنیم کار میکنه با این متد اخر
        }
    }
}