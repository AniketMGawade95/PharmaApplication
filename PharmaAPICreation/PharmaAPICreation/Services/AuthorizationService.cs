using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{


    public class AuthorizationService : IAuthorization
    {
        ApplicationDbContext db;
        public AuthorizationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddEmp(object data)
        {
            if (data != null)
            {
                db.Users.Add((User)data);
                db.SaveChanges();
            }
        }

        public User AuthenticateUser(string Username, string Password)
        {
            var user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == Username);


            //var user = db.Users.Include(u => u.Role).Select(x=>new LoginResponseDTO()
            //{
            //    Username = x.Username,
            //    BranchId = x.BranchId,
            //    RoleName=x.Role.RoleName,
            //    Password=x.PasswordHash
            //}).FirstOrDefault(u => u.Username == Username && u.Password== Password);

            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        public List<Branch> fetchbranch()
        {
            var data = db.Branches.ToList();
            return data;
        }
    }
}
