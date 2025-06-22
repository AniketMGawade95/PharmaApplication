using PharmaAPICreation.Data;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class MedicineService:IMedicineRepository
    {
        public readonly ApplicationDbContext db;
        public MedicineService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddMedicine(Medicine medicine)
        {
            db.Medicines.Add(medicine);
            db.SaveChanges();
        }

        public void DeleteMedicine(int id)
        {
            var medicine = db.Medicines.Find(id);
            if (medicine != null)
            {
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
        }

        public List<Medicine> GetAllMedicines()
        {
           return db.Medicines.ToList();
        }

        public Medicine GetMedicineById(int id)
        {
            //return db.Medicines.FirstOrDefault(x => x.MedicineId == id);
            return db.Medicines.Find(id);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            db.Medicines.Update(medicine);
            db.SaveChanges();
        }
    }
}
