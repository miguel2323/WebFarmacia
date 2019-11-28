

/// <summary>
/// esta clases alimenta la base de datos
/// </summary>

namespace WebFarmacia.Web.Data
{   
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        //inyeccion de deendencia a la base de datos

        private Random random;

        public SeedDb(DataContext context)
        {
            this.context=context;
            this.random = new Random();
        }

        //metodo para alimentar la base de datos
        //este metdo es asincrono

        public async Task SeedAsync()
        {
            // verificando que la base de datos este creada
            await this.context.Database.EnsureCreatedAsync();

            // registro de la base de datos
            // await CheckPetypesAsync();
            // await CheckOwnerAsync();
            //await CheckMedicinaAsync();

            if (!this.context.Medicinas.Any())
            {
                this.AddMedicina("Omeprazol");
                this.AddMedicina("Atamel");
                this.AddMedicina("Teragrip");
                //grabando los cambios
                await this.context.SaveChangesAsync();
            }
        }

        private void AddMedicina(string name)
        {
            this.context.Medicinas.Add(new Medicina
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                stock = this.random.Next(100)
                
            });
        }

    }
}
