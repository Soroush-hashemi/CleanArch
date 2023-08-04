using Domain.Base;
using Domain.Exception;

namespace Domain;

public class ProductImage : BaseEntity
{
    public string ImageName { get; private set; }
    public long ProductId { get; private set; }

    public ProductImage(long productId, string imageName)
    {
        NullOrEmptyException.CheckString(imageName, "ImageName");
        ProductId = productId;
        ImageName = imageName;
    }
}
