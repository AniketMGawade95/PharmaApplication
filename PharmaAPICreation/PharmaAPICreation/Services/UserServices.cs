using PharmaAPICreation.Data;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class UserServices:IUser
    {
        ApplicationDbContext db;

        public UserServices(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
