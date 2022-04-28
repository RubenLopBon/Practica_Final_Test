using System.Text.Json;

namespace CrazyProcessor.Auth
{
    public class AuthService : IAuthService
    {
        private Dictionary<string, User> users = new();

        public AuthService()
        {
            this.LoadUsers();
        }

        public User? Login(string email, string password)
        {
            if (!this.users.TryGetValue(email, out var user))
            {
                return null;
            }

            return password.Equals(user.Password) ? user : null;
        }

        private void LoadUsers()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jsonString = File.ReadAllText("data/users.json");
            var users = JsonSerializer.Deserialize<User[]>(jsonString, options);
            if (users != null)
            {
                this.users = users.ToDictionary(u => u.Email);
            }
        }
    }
}
