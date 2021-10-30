using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
