namespace Domain;

public class ProductImages
{
    public string ImageName { get; private set; }
    public long Id { get; private set; }
    public Guid ProductId { get; private set; }

    public ProductImages(Guid productId, string imageName)
    {
        if (productId == null)
            throw new ArgumentNullException(nameof(productId));

        if (imageName == null)
            throw new ArgumentNullException(nameof(imageName));
        
        productId = ProductId;
        imageName = ImageName;
    }
}
