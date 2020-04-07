﻿namespace WebFarmacia.Web.Helpers
{
    using System.Threading.Tasks;
    using Data.Entities;
     using Microsoft.AspNetCore.Identity;
    public interface IuserHelpers
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);


    }
}
