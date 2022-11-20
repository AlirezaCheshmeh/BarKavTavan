using BarKavTavan.Domain.Entities;

namespace BarKavTavan.Services
{
    public interface IUser
    {
        bool MobileNumberExist(string Mobile);

        int AddUser(User u);

        User Login(string Mobile, string password);

        User ForgetPassword(string mobile);

        bool CheckUserRole(string RoleName, string Mobile);

        string getRoleName(int id);

        bool Actived(string Code);

    }
}
