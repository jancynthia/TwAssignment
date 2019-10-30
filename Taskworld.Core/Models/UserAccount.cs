namespace Taskworld.Core
{
    public class UserAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int UserServer { get; set; }

        public UserAccountType UserAccountType { get; set; }
    }
}
