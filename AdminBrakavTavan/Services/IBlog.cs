using AdminBarKavTavan.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AdminBarKavTavan.Services
{
    public interface IBlog
    {
        int addBlog(blogs bloged);


        bool Deleteblog(int blogId);


        int findRolid(string roleName);

    }
}
