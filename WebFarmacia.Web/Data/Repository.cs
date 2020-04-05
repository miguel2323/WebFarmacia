
namespace WebFarmacia.Web.Data
{
    using Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Repository : IRepository
    {
        private readonly DataContext context;

        // aqui vamos a inyectar la conexion a la base de datos

        public Repository(DataContext context)
        {
            this.context = context;
        }


        // lista de medicinas
        public IEnumerable<Medicina> GetMedicinas()
        {
            return this.context.Medicinas.OrderBy(m => m.Name);
        }

        public Medicina GetMedicina(int id)
        {
            return this.context.Medicinas.Find(id);//buaqueda por clave primaria

        }

        //cargando el nuevo medicina
        public void AddMedicina(Medicina medicina)
        {
            this.context.Medicinas.Add(medicina);
        }

        //actualizando las medicinas

        public void UpdateMedicina(Medicina medicina)
        {
            this.context.Medicinas.Update(medicina);
        }

        //elimandon medicinas
        public void RemoveMedicina(Medicina medicina)
        {
            this.context.Medicinas.Remove(medicina);
        }

        //grABAR TODOS LOS Cambios
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;

        }
        // si la madicina existe manda verdadero sino mnda falso
        public bool MedicinaExists(int id)
        {
            return this.context.Medicinas.Any(m => m.Id == id);
        }

    }
}
