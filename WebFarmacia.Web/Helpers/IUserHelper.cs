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

    }
}