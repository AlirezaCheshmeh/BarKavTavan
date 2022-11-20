
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BarKavTavan.Domain.Entities
{
    public class User
    {
        [Key]
        public int Userid { get; set; }
  
        public string Email { get; set; }
        public string  UserName { get; set; }

        public bool isActive { get; set; }

        public string  Code { get; set; }

        public string Mobile { get; set; }
        public string  password { get; set; }
        public int Roleid { get; set; }

        public Role Role { get; set; }


    }
}
