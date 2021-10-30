﻿using NORTWND.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public Role Role { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

    }
}
