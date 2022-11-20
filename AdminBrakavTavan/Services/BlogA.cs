

using AdminBarKavTavan.Domain;
using AdminBarKavTavan.Entities;

namespace AdminBarKavTavan.Services
{
    public class BlogA : IBlog
    {
        private readonly DataContext _db;

        public BlogA(DataContext dataContext)
        {
            _db = dataContext;
        }
        public int addBlog(blogs bloged)
        {
            _db.Add(bloged);
            _db.SaveChanges();
            return bloged.blogid;
        }



        public bool Deleteblog(int blogId)
        {
            var r = _db.Blog.FirstOrDefault(c => c.blogid == blogId);
            if (r != null)
            {
                _db.Remove(r);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public int findRolid(string roleName)
        {
            var r = _db.User.Where(c => c.UserName == roleName).FirstOrDefault();
            return r.Userid;
        }
    }
}
