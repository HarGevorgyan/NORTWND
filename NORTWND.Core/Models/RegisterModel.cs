using System.ComponentModel.DataAnnotations;

namespace NORTWND.Core.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The password cannot be more than 10 symbols")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
