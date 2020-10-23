namespace WebFarmacia.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
     using WebFarmacia.Web.Models;
    public class UserHelper:IUserHelper
    {   
      private readonly UserManager<User> userManager;
      private readonly SignInManager<User> signInManager;
      private readonly RoleManager<IdentityRole> roleManager;
      public UserHelper(
          UserManager<User> userManager, 
          SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
      {
        this.userManager= userManager;
        this.signInManager=signInManager;
        this.roleManager=roleManager;


      }
        public async Task<IdentityResult> AddUserAsync(User user,string password)
        {
        return await this.userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> loginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false
            );
        }

        public  async Task LogoutAsync()
        {
         await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
          return await this.userManager.UpdateAsync(user);

        }
         public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
           return await this.userManager.ChangePasswordAsync(user,oldPassword,newPassword);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
         return  await this.userManager.FindByEmailAsync(email);
          
        }

        public async Task checkRoleAsync(string roleName)
        {
           var rolexists=await this.roleManager.RoleExistsAsync(roleName);
            if (!rolexists)
            {
              await this.roleManager.CreateAsync(new IdentityRole
              {
                Name=roleName
              });
                
            }
               
           
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
           await this.userManager.AddToRoleAsync(user,roleName);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
         return await this.userManager.IsInRoleAsync(user,roleName);   
        }
    }
    
} 