namespace GTracker.Domain.DTO.User
{
    public class LoginResponseUserDTO
    {
        public bool Authenticated { get; set; }
        public string AccessToken { get; set; }
    }
}