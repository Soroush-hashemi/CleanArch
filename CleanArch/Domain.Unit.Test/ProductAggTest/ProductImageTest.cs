using FluentAssertions;
using Xunit;

namespace Domain.Unit.Test.ProductAggTest
{
    public class ProductImageTest
    {
        [Fact]
        public void Constructor_Should_Create_New_Image_When_Date_Was_Ok()
        {
            var productImage = new ProductImage(1, "ImageName.png");

            productImage.ImageName.Should().Be("ImageName.png");
        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_Date_Was_Null()
        {
            var productImage = () => new ProductImage(1, "");

            productImage.Should().ThrowExactly<NotImplementedException>().WithMessage("ImageName is null");
        }
    }
}
