
/// <summary>
/// esta clases alimenta la base de datos
/// </summary>

namespace WebFarmacia.Web.Data
{   
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using WebFarmacia.Web.Helpers;
    public class SeedDb
    {
        private readonly DataContext context;
        //inyeccion de deendencia a la base de datos
       private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context=context;
            this.userHelper=userHelper;
            this.random = new Random();
        }

        //metodo para alimentar la base de datos
        //este metdo es asincrono

        public async Task SeedAsync()
        {
            // verificando que la base de datos este creada
            await this.context.Database.EnsureCreatedAsync();
            /*Crando los roles de usuarios */
            await this.userHelper.checkRoleAsync("Admin");
            await this.userHelper.checkRoleAsync("customer");


            //Creando el usuario

            var user = await this.userHelper.GetUserByEmailAsync("miguelrojas8143@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Miguel",
                    LasName = "Rojas",
                    Email = "miguelrojas8143@gmail.com",
                    UserName = "miguelrojas8143@gmail.com",
                    PhoneNumber="04266828897"

                };
                var resul = await this.userHelper.AddUserAsync(user, "123456");
                if (resul !=IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
                await this.userHelper.AddUserToRoleAsync(user,"Admin");

            }
         var isInRole= await this.userHelper.IsUserInRoleAsync(user,"Admin");
          if(!isInRole)
         {
             await this.userHelper.AddUserToRoleAsync(user,"Admin");
         }


        
            if (!this.context.Medicinas.Any())
            {
                this.AddMedicina("Omeprazol", user);
                this.AddMedicina("Atamel", user);
                this.AddMedicina("Teragrip", user);
                //grabando los cambios
                await this.context.SaveChangesAsync();
            }
        }

        private void AddMedicina(string name,User user)
        {
            this.context.Medicinas.Add(new Medicina
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                stock = this.random.Next(100),
                User = user
            });
        }

    }
}
