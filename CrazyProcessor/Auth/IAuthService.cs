namespace CrazyProcessor.Auth
{
    public interface IAuthService
    {
        User? Login(string email, string password);
    }
}
