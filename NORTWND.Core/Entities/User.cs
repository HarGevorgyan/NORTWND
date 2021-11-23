using NORTWND.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace NORTWND.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public Role Role { get; set; }
        
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="The password cannot be more than 10 symbols")] 
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

    }
}
