using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface IMedicineRepository
    {
        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        void DeleteMedicine(int id);
        Medicine GetMedicineById(int id);
        List<Medicine> GetAllMedicines();
    }
}
