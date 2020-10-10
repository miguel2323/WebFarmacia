namespace WebFarmacia.Web.Controllers
{
        using Microsoft.AspNetCore.Mvc;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using WebFarmacia.Web.Helpers;
        using WebFarmacia.Web.Models;
        using Microsoft.AspNetCore.Identity;
        using WebFarmacia.Web.Data.Entities;
        public class AccountController: Controller
        {

        private readonly IUserHelper userlHelper;


            public AccountController(IUserHelper userHelper)
            {
                this.userlHelper=userHelper;
            }

            public IActionResult Login()
            {
            if(this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index","Home");
            }
            return this.View();
            }

            [HttpPost] 
            public async Task<IActionResult> Login(LoginViewModel model)
            { 
                if (this.ModelState.IsValid)
                {
                var result=await this.userlHelper.loginAsync(model);
                if(result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturUrl"))
                    {
                    return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index","Home");
                }
            }
            this.ModelState.AddModelError(string.Empty,"Failed to login");
            return this.View(model);        

        }
        public async Task<IActionResult> Logout()
        {
         await this.userlHelper.LogoutAsync();
        return this.RedirectToAction("Index","Home");
        }

       public IActionResult Register()
       {
           return this.View();
       }
    [HttpPost]

    public async Task<IActionResult> Register(RegisterNewUserViewModel model)
    {    
        
        if (this.ModelState.IsValid)
                {
                    var user=await this.userlHelper.GetUserByEmailAsync(model.Username);
                    if(user == null)
                    {
                        user= new User
                        {
                      FirstName=model.FirstName,
                      LasName=model.LastName,
                      Email=model.Username,
                      UserName=model.Username
                     };
                    var  result =await this.userlHelper.AddUserAsync(user,model.Password);
                    if (result !=IdentityResult.Success)
                 {
                  this.ModelState.AddModelError(string.Empty,"the user couldn't be created ");
                  return this.View(model);  
                 }
                 var loginViewModel=new LoginViewModel
                 {
                    Password= model.Password,
                    RememberMe=false,
                    Username=model.Username

                 };
                 var  result2 =await this.userlHelper.loginAsync(loginViewModel);
                 if(result2.Succeeded)
                   {
                     return this.RedirectToAction("Index","Home");
                    }
                 this.ModelState.AddModelError(string.Empty,"The user couldn't be login");
                 return this.View(model);
               }
               this.ModelState.AddModelError(string.Empty,"The username is already registerd.");
            }
            
           return this.View(model);
        }   
    }

    
}