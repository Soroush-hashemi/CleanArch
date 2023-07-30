using Domain.Base;

namespace Domain;

public class ProductImages : BaseEntity
{
    public string ImageName { get; private set; }
    public long ProductId { get; private set; }

    public ProductImages(long productId, string imageName)
    {
        if (productId == null)
            throw new ArgumentNullException(nameof(productId));

        if (imageName == null)
            throw new ArgumentNullException(nameof(imageName));

        productId = ProductId;
        imageName = ImageName;
    }
}
