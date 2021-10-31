using NORTWND.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Models
{
    public class UserEditModel
    {
        public string Name {  get; set; }

        public string LastName {  get; set; }

        public string UserName {  get; set; }

        public string Password {  get; set; }
        public string OldUserName { get; set; }

        public string OldPassword { get; set; }

    }
}
