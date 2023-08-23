using Domain.Base;
using Domain.Repositories;
using MediatR;

namespace Application.Command.Products.Edit
{
    public class EditProductCommandhandler : IRequestHandler<EditProductCommand, long>
    {
        private readonly IProductRepository _repository;
        public EditProductCommandhandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            product.Edit(request.Title, Money.FromRial(request.Price)); // اول میدیمش به دامین ببینیم با قوانین کسب وکار سازگاری داره یا نه 
            _repository.Update(product); // بعدش میدیمش به ریپو
            await _repository.SaveChanges();
            return product.Id;
        }
    }
}