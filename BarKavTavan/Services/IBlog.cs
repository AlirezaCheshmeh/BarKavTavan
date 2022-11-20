using BarKavTavan.Domain.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BarKavTavan.Services
{
    public interface IBlog
    {
        int addBlog(blogs bloged);


        bool Deleteblog(int blogId);


        int findRolid(string roleName);


        blogs getSingleBlog(int id);

    }
}
