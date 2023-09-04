using Application.Query.Products.DTOs;
using MediatR;

namespace Application.Query.Products.GetById;
public record GetProductByIdQuery(long ProductId) : IRequest<ProductDto>; // اینجا نوع دیتایی که یوزر با ما میده رو تعیین میکنیم و ریکوست و جنسش رو برای مدیتور مشخص میکنیم 
