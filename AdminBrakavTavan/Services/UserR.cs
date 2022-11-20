
using AdminBarKavTavan.Domain;
using AdminBarKavTavan.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminBarKavTavan.Services
{
    public class UserR : IUser

    {
        private readonly DataContext _db;

        public UserR(DataContext db)
        {
            _db = db;
        }

        public bool Actived(string Code)
        {
            var r = _db.User.Where(c => c.isActive == false && c.Code == Code).FirstOrDefault();
            if (r != null)
            {
                r.Code = Utility.ActiveCode();
                r.isActive = true;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public int AddUser(User u)
        {
            _db.User.Add(u);
            _db.SaveChanges();
            return u.Userid;
        }

        public bool CheckUserRole(string RoleName, string Mobile)
        {
            return _db.User.Include(c => c.Role)
                           .Any(c => c.Mobile == Mobile && c.Role.RoleName == RoleName);
        }

        public User ForgetPassword(string Mobile)
        {

            return _db.User.FirstOrDefault(u => u.Mobile == Mobile);
        }

        public string getRoleName(int id)
        {
            var r = _db.Role.Find(id);
            return r.RoleName;
        }

        public User Login(string Mobile, string password)
        {
            string hashpassword = Utility.HashPssword(password);
            return _db.User.FirstOrDefault(c => c.UserName == Mobile && c.password == hashpassword);
        }

        public bool MobileNumberExist(string Mobile)
        {
            return _db.User.Any(c => c.Mobile == Mobile);
        }
    }
}
