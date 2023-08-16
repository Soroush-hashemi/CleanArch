using MediatR;

namespace Application.Command.Products.Create
{
    public class CreateProductCommand : IRequest<long>
    {
        public CreateProductCommand(string title , int price)
        {
            Title = title;
            Price = price; 
        }

        public string Title { get; set; }
        public int Price { get; set; }
    }
}
