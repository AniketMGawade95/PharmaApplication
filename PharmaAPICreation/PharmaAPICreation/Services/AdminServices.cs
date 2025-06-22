using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;
using System.Data;
using System.Threading.Tasks;

namespace PharmaAPICreation.Services
{


    public class AdminServices:IAdmin
    {
        ApplicationDbContext db;

        public AdminServices(ApplicationDbContext db)
        {
            this.db = db;
        }







        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public async Task<List<UserDetailDTO>> FetchUsersAsync()
        {
            return await db.Users.Include(u => u.Role).Include(u => u.Branch)
                .Select(u => new UserDetailDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    UserEmail = u.UserEmail,
                    PasswordHash=u.PasswordHash,
                    RoleId = u.RoleId,
                    RoleName = u.Role.RoleName,
                    BranchId = u.BranchId,
                    BranchName = u.Branch.BranchName,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    UpdatedBy = u.UpdatedBy,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            //return await db.Users.FindAsync(id);
            return await db.Users
        .Include(u => u.Role)
        .Include(u => u.Branch)
        .FirstOrDefaultAsync(u => u.UserId == id);

        }

        public async Task<bool> UpdateUserAsync(int id, User updatedUser)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return false;

            user.Username = updatedUser.Username;
            user.UserEmail = updatedUser.UserEmail;
            user.PasswordHash = updatedUser.PasswordHash;
            user.RoleId = updatedUser.RoleId;
            user.BranchId = updatedUser.BranchId;
            user.UpdatedBy = updatedUser.UpdatedBy;
            user.UpdatedAt = DateTime.Now;

            db.Users.Update(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return false;

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return true;
        }
















        public void AddRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void AddBranches(object data)
        {
            
            if (data != null)
            {
                db.Branches.Add((Branch)data);
                db.SaveChanges();
            }
        }

        public void AddSupplier(Supplier data)
        {
            if (data != null)
            {
                db.Suppliers.Add(data);
                db.SaveChanges();
            }
        }

        public async Task<List<Role>> FetchRolesAsync()
        {
            var data = await db.Roles.ToListAsync();
            return data;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await db.Roles.FindAsync(id); 
            if (role == null)
            {
                return false;
            }

            db.Roles.Remove(role);
            await db.SaveChangesAsync();
            return true;
        }

        public bool DeleteBranches(int id)
        {
            var branch= db.Branches.Find(id);
            if (branch==null)
            {
                return false;
            }
            db.Branches.Remove(branch);
            db.SaveChanges();
            return true;
        }

        public async Task<List<Branch>> FetchBranchesAsync()
        {
            var data=await db.Branches.ToListAsync();           
            return data;            
          
        }

        public async Task<List<SupplierDTO>> FetchSuppliersAsync()
        {
            var data = await db.Suppliers.Select(x=> new SupplierDTO() { 
            
                SupplierId= x.SupplierId,
                Name= x.Name,
                Contact= x.Contact,
                Address= x.Address,
                CreatedBy= x.CreatedBy,
                CreatedAt= x.CreatedAt,
                UpdatedBy= x.UpdatedBy,
                UpdatedAt= x.UpdatedAt
            
            }).ToListAsync();

            return data;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            var supp = await db.Suppliers.FindAsync(id);
            if (supp == null)
            {
                return false;
            }

            db.Suppliers.Remove(supp);
            await db.SaveChangesAsync();
            return true;

        }

        //public async Task<List<LoginResponseDTO>> fetchusers()
        //{
        //    var data = await db.Users.Include(x=>x.Role).Include(x=>x.Branch).Select(x => new LoginResponseDTO()
        //    {

        //        UserId= x.UserId,
        //        Username=x.Username,
        //        UserEmail=x.UserEmail,
        //        PasswordHash=x.PasswordHash,
        //        RoleName=x.Role.RoleName,
        //        BranchId=x.Branch.BranchId,
        //        CreatedDate=x.CreatedDate,
        //        CreatedBy = x.CreatedBy,
        //        UpdatedAt = x.UpdatedAt,
        //        UpdatedBy=x.UpdatedBy

        //    }).ToListAsync();

        //    return data;
        //}

        //public Task<bool> DeleteUserAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}





        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await db.Roles.FindAsync(id);
        }

        public async Task<bool> UpdateRoleAsync(int id, Role updatedRole)
        {
            var existingRole = await db.Roles.FindAsync(id);
            if (existingRole == null)
            {
                return false;
            }

            
            existingRole.RoleName = updatedRole.RoleName;

            //db.Roles.Update(existingRole);
            await db.SaveChangesAsync();
            return true;
        }



        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await db.Branches.FindAsync(id); 
        }

        public async Task<bool> UpdateBranchAsync(int id, Branch updatedBranch)
        {
            var existingBranch = await db.Branches.FindAsync(id);
            if (existingBranch == null)
                return false;

            existingBranch.BranchName = updatedBranch.BranchName;
            existingBranch.BranchAddress = updatedBranch.BranchAddress;

            db.Branches.Update(existingBranch);
            await db.SaveChangesAsync();
            return true;
        }




        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await db.Suppliers.FindAsync(id); 
        }

        public async Task<bool> UpdateSupplierAsync(int id, Supplier updatedSupplier)
        {
            var existingSupplier = await db.Suppliers.FindAsync(id);
            if (existingSupplier == null)
                return false;

            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.Contact = updatedSupplier.Contact;
            existingSupplier.Address = updatedSupplier.Address;
            existingSupplier.UpdatedBy = updatedSupplier.UpdatedBy;
            existingSupplier.UpdatedAt = DateTime.Now;

            db.Suppliers.Update(existingSupplier);
            await db.SaveChangesAsync();
            return true;
        }









    }
}
