using MediatR;

namespace Application.Command.Products.Edit
{
    public class EditProductCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
