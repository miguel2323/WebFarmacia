
namespace WebFarmacia.Web.Data
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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