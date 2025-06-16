using PharmaAPICreation.Data;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class PharmacistService:IPharmacist
    {
        ApplicationDbContext db;

        public PharmacistService(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
