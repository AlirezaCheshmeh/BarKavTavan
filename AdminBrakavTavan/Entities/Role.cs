using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace AdminBarKavTavan.Entities
{
    public class Role
    {
        [Key]
        public int Roleid { get; set; } 
        public string  RoleName { get; set; }


        public IEnumerable<User> user { get; set; }
        public IEnumerable<blogs> blog { get; set; }

    }
}
