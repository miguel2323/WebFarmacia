namespace WebFarmacia.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using WebFarmacia.Web.Helpers;

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

}




}