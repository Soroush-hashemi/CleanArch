using Application.Command.Exceptions;
using Domain.Base;
using Domain.Entities.ProductAgg.Events;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Edit;

public class EditProductCommandhandler : IRequestHandler<EditProductCommand, long>
{
    private readonly IProductRepository _repository;
    private readonly IMediator _mediator;
    public EditProductCommandhandler(IProductRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    public async Task<long> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id);
        if (product is null)
            ProductNotFoundException.Check();

        product.Edit(request.Title, Money.FromRial(request.Price)); // اول میدیمش به دامین ببینیم با قوانین کسب وکار سازگاری داره یا نه 
        _repository.Update(product); // بعدش میدیمش به ریپو
        await _repository.SaveChanges();
        await _mediator.Publish(new ProductEdited(product.Id, product.Title));
        return product.Id;
    }
}