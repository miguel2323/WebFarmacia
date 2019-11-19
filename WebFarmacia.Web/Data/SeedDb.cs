using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFarmacia.Web.Data.Entities;

/// <summary>
/// esta clases alimenta la base de datos
/// </summary>

namespace WebFarmacia.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        //inyeccion de deendencia a la base de datos
        //
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        //metodo para alimentar la base de datos
        //este metdo es asincrono

        public async Task SeedAsync()
        {
            // verificando que la base de datos este creada
           await _context.Database.EnsureCreatedAsync();
           
            // registro de la base de datos
              await CheckPetypesAsync();
              await CheckOwnerAsync();
              await CheckMedicinaAsync();
       }

        //medicinas
        private async Task CheckMedicinaAsync()
        {
            if (!_context.Medicinas.Any())
            {
                _context.Medicinas.Add(new Medicinas { Name = "" });
                //grabando los cambios
                await _context.SaveChangesAsync();
            }
        }

        //agragando propietario o farmacia
        private async Task CheckOwnerAsync()
        {
            if (!_context.Owners.Any()) {
                AddOwner("123456", "bladimir", "velasque", "1233341", "2334543", "caracas calle maneiro");

               //grabando los cambios
                await _context.SaveChangesAsync();
            }
             
        }

        private void AddOwner(string document,string firstName,string lastName,string fixedPhone, string cellPhone, string address)
        {
            _context.Owners.Add(new Owner
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = fixedPhone,
                CellPhone = cellPhone,
                Address=address
            }); 

        }

        //chequear tipo de medicinas
        private async Task CheckPetypesAsync()
        {
            //si no hay tipo de medicina
            if (!_context.TipoMedicinas.Any())
            {
                _context.TipoMedicinas.Add(new TipoMedicinas { Name = "Antibiotico" });
                _context.TipoMedicinas.Add(new TipoMedicinas { Name = "AntiAlergico" });
                _context.TipoMedicinas.Add(new TipoMedicinas { Name = "Gripe" });
                _context.TipoMedicinas.Add(new TipoMedicinas { Name = "Fiebre"});
                //grabando los cambios
                await _context.SaveChangesAsync();
            }
        }

    }
}
