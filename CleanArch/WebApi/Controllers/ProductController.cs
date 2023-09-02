using Application.Command.Products.Create;
using Application.Command.Products.Delete;
using Application.Command.Products.Edit;
using Application.Query.Products.DTOs;
using Application.Query.Products.GetById;
using Application.Query.Products.GetList;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Entities.ProductAgg;
using WebApi.ViewModels.Products;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return _mapper.Map<List<ProductViewModel>>(products).AddLinks();
        }

        [HttpGet("{Id}")] // اینجا ما دیتا رو از روت یا مسیر دریافت میکنیم
        public async Task<ProductViewModel> GetProduct(long Id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(Id));
            return _mapper.Map<ProductViewModel>(product).AddLinks();
        }

        [HttpPost] // اینجا ما دیتا رو از بادی دریافت میکنیم
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            var url = Url.Action(nameof(GetProduct), "Product", new { Id = result }, Request.Scheme);
            return Created(url, result);
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
