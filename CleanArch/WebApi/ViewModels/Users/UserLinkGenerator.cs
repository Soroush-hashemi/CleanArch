namespace WebApi.ViewModels.Users;

public static class UserLinkGenerator
{
    private static string AuthUrl = "https://localhost:7121/Auth";
    public static UserViewModel AddLinks(this UserViewModel viewModel)
    { // برای یکی از محصولات لینک میسازه 

        if (viewModel == null)
            return null;

        var links = new List<LinkDto>()
            {
                new LinkDto(AuthUrl,"update_auth",HttpMethod.Put.Method),
            };
        viewModel.Links.AddRange(links);
        return viewModel;
    }

    public static List<UserViewModel> AddLinks(this List<UserViewModel> viewModel)
    { // برای لیستی از محصولات لینک میسازه 
        if (viewModel == null)
            return null;
        viewModel.ForEach(item =>
        {
            var links = new List<LinkDto>()
            {
                    new LinkDto(AuthUrl,"update_auth",HttpMethod.Put.Method),
                    new LinkDto($"{AuthUrl}/{item.Id}","self",HttpMethod.Get.Method),
            };
            item.Links.AddRange(links);
        });
        return viewModel;
    }
}