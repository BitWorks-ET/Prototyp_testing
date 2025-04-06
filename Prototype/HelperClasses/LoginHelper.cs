using Prototype.Models;
using Blazored.SessionStorage;

namespace Prototype.HelperClasses
{
    public static class LoginHelper
    {
        public static async Task<bool> LogInUser(String username, String passwordHash, ISessionStorageService sessionStorage)
        {
            Person user = Application.Instance.GetPerson(username);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(passwordHash, user.PasswordHash))
                {
                    await sessionStorage.SetItemAsync("isLoggedIn", true);
                    await sessionStorage.SetItemAsync("username", username);
                    return true;
                }
            }

            return false;
        }
    }
}
