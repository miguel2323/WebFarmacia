
namespace WebFarmacia.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        void AddMedicina(Medicina medicina);

        Medicina GetMedicina(int id);

        IEnumerable<Medicina> GetMedicinas();

        bool MedicinaExists(int id);

        void RemoveMedicina(Medicina medicina);

        Task<bool> SaveAllAsync();

        void UpdateMedicina(Medicina medicina);
    }
}