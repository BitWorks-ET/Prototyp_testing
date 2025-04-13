using Prototype.Models;
using Blazored.SessionStorage;
using Prototype.Models.Rights;

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
                    await sessionStorage.SetItemAsync("user", user);
                    if (Application.Instance.GetOrganization(user.OrganizationId).OrgAdmins.Contains(user))
                    {
                        await sessionStorage.SetItemAsync("rightsType", "Organizer");
                        await sessionStorage.SetItemAsync("rights", new Organizer());
                    }
                    else
                    {
                        await sessionStorage.SetItemAsync("rightsType", "Member");
                        await sessionStorage.SetItemAsync("rights", new Member());
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
