
namespace TaskOrganizer
{
    public class User
    {
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public User() { }

        public User(string UserLogin, string UserPassword)
        {
            this.UserLogin = UserLogin;
            this.UserPassword = UserPassword;
        }
    }
}
