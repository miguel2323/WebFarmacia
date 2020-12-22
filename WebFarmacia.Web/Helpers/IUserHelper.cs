namespace WebFarmacia.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using WebFarmacia.Web.Models;

    public interface IUserHelper
    {
      Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user,string password);

        Task<SignInResult> loginAsync(LoginViewModel model);
       
       Task LogoutAsync();


       Task<IdentityResult> UpdateUserAsync(User user);

       Task<IdentityResult> ChangePasswordAsync(User user,string oldPassword,string newPassword);
        Task checkRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}