using PharmaAPICreation.Data;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class CashierServices:ICashier
    {
        ApplicationDbContext db;

        public CashierServices(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
