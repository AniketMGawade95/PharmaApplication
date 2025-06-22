using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface IAdmin
    {


        //Task<List<LoginResponseDTO>> fetchusers();
        //Task<bool> DeleteUserAsync(int id);




        void AddUser(User user);
        Task<List<UserDetailDTO>> FetchUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int id, User updatedUser);
        Task<bool> DeleteUserAsync(int id);




        //Task AddUserAsync(User user);
        //Task<List<UserDetailDTOnew>> GetAllUsersAsync();
        //Task<UserDetailDTOnew> GetUserByIdAsync(int id);
        //Task UpdateUserAsync(UpdateUserDTOnew dto);

        //Task DeleteUserAsync(int id);





        void AddRole(Role role);
        Task<List<Role>> FetchRolesAsync();
        Task<bool> DeleteRoleAsync(int id);
        Task<Role> GetRoleByIdAsync(int id);
        Task<bool> UpdateRoleAsync(int id, Role updatedRole);








        void AddBranches(object data);
        Task<List<Branch>> FetchBranchesAsync();
        bool DeleteBranches(int id);
        Task<Branch> GetBranchByIdAsync(int id);
        Task<bool> UpdateBranchAsync(int id, Branch updatedBranch);




        void AddSupplier(Supplier data);
        Task<List<SupplierDTO>> FetchSuppliersAsync();
        Task<bool> DeleteSupplier(int id);
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<bool> UpdateSupplierAsync(int id, Supplier updatedSupplier);


    }
}
