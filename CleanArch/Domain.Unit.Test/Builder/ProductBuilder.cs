using Domain.Base;
using Domain.Entities;

namespace Domain.Unit.Test.Builder;

internal class ProductBuilder
{
    private string Title = "Test";
    private Money Price = new Money(1000000);

    public ProductBuilder SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public ProductBuilder SetMoney(int rialPrice)
    {
        Price = new Money(rialPrice);
        return this;
    }

    public Product Build()
    { return new Product(Title, Price); }
}


