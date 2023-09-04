namespace WebApi.ViewModels.Products
{
    public static class ProductLinkGenerator
    {
        private static string ProductUrl = "https://localhost:7121/Product";
        public static ProductViewModel AddLinks(this ProductViewModel viewModel)
        { // برای یکی از محصولات لینک میسازه 

            if (viewModel == null)
                return null;

            var links = new List<LinkDto>()
            {
                new LinkDto(ProductUrl,"update_product",HttpMethod.Put.Method),
                new LinkDto($"{ProductUrl}/{viewModel.Id}","delete_product",HttpMethod.Delete.Method),
            };
            viewModel.Links.AddRange(links);
            return viewModel;
        }

        public static List<ProductViewModel> AddLinks(this List<ProductViewModel> viewModel)
        { // برای لیستی از محصولات لینک میسازه 
            if (viewModel == null)
                return null;
            viewModel.ForEach(item =>
            {
                var links = new List<LinkDto>()
                {
                    new LinkDto(ProductUrl,"update_product",HttpMethod.Put.Method),
                    new LinkDto($"{ProductUrl}/{item.Id}","delete_product",HttpMethod.Delete.Method),
                    new LinkDto($"{ProductUrl}/{item.Id}","self",HttpMethod.Get.Method),
                };
                item.Links.AddRange(links);
            });
            return viewModel;
        }
    }
}
