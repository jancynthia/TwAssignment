using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Taskworld.Core
{
    public static class UserAccountProvider
    {
        private static IList<UserAccount> UserAccounts { get; set; }

        public static UserAccount GetUserAccount(UserAccountType userAccountType, string username = "")
        {
            var userAccounts = LoadUserAccounts();
            return userAccounts.FirstOrDefault(u => u.UserAccountType == userAccountType && string.IsNullOrWhiteSpace(username) ? true : u.Username == username);
        }

        private static IList<UserAccount> LoadUserAccounts()
        {
            if(UserAccounts == null)
            {
                UserAccounts = JsonConvert.DeserializeObject<List<UserAccount>>(File.ReadAllText(FilePath.UserAccount));
            }

            return UserAccounts;
        }
    }
}
