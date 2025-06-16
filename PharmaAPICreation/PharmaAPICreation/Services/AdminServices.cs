using PharmaAPICreation.Data;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{


    public class AdminServices:IAdmin
    {
        ApplicationDbContext db;

        public AdminServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddRoles(object data)
        {
            
            if (data != null)
            {
                db.Roles.Add((Role)data);
                db.SaveChanges();
            }
        }
        public void AddBranches(object data)
        {
            
            if (data != null)
            {
                db.Branches.Add((Branch)data);
                db.SaveChanges();
            }
        }
    
    }
}
