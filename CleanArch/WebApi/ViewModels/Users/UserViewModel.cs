namespace WebApi.ViewModels.Users
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Family { get; set; }
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
