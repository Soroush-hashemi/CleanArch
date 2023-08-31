using Application.Command.Products.Create;
using Application.Command.Products.Delete;
using Application.Command.Products.Edit;
using Application.Query.Products.DTOs;
using Application.Query.Products.GetById;
using Application.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Entities.ProductAgg;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetProducts()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpGet("{Id}")]
        public async Task<ProductDto> GetProduct(long Id)
        {
            return await _mediator.Send(new GetProductByIdQuery(Id));
        }

        [HttpPost]
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

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
