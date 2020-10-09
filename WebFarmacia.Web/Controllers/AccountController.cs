namespace WebFarmacia.Web.Controllers
{
        using Microsoft.AspNetCore.Mvc;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using WebFarmacia.Web.Helpers;
        using WebFarmacia.Web.Models;
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

    }
}