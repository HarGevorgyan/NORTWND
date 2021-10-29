﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Models
{
    public class CustomersViewModel
    {
        public string CustomerId {  get; set; }
        public string CompanyName {  get; set; }
        public string Country {  get; set; }
        public string City {  get; set; }
        public string Region {  get; set; }
        public int Customers { get; set; }
    }
}