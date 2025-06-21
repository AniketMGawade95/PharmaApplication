using PharmaAPICreation.Models;

namespace PharmaAPICreation.Repo
{
    public interface IAuthorization
    {
        User AuthenticateUser(string Username,string PasswordHash);

        List<Branch> fetchbranch();

        void AddUser(object data);
    }
}
