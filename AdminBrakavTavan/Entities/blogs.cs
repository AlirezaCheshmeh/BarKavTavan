using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBarKavTavan.Entities
{
    public class blogs
    {
        [Key]
        public int blogid { get; set; }

        public string description { get; set; }
        public string titleb { get; set; }
        public string litledes { get; set; }

        public string image { get; set; }
        public DateTime datetime { get; set; }
        public string  Username { get; set; }

        public int Roleid { get; set; }
        public Role role { get; set; }


    }
}
